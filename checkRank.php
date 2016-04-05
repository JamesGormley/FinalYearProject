<?php
    // Send variables for the MySQL database class.
    $db = mysql_connect('localhost', 'root', '') or die('Could not connect: ' . mysql_error());
    mysql_select_db('fyp') or die('Could not select database');
 
 
	// Strings must be escaped to prevent SQL injection attack. 
	$name = mysql_real_escape_string($_GET['name'], $db); 
	//Rank is not a field in the database. Therefore this nested query declares it as an alias
	
	//*******************************************************************************************
	// This code referenced from http://stackoverflow.com/questions/26040215/php-mysql-highscores-get-rank-of-current-player-with-a-lot-of-scores-multiple
	//*******************************************************************************************
    $query = "SELECT Rank, UserName,Score From(SELECT UserName, Score, FIND_IN_SET( Score, (
				SELECT GROUP_CONCAT( Score ORDER BY Score DESC ) 
				FROM highscores )
				) AS Rank
				FROM highscores
				WHERE UserName = '$name') AS r";
				
	//******************************************************************************************
	// End of reference
	//******************************************************************************************
	
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
 
    $num_results = mysql_num_rows($result);  
 
    for($i = 0; $i < $num_results; $i++)
    {
         $row = mysql_fetch_array($result);
         echo $row['Rank'] . "\t" . $row['UserName'] . "\t" . $row['Score'] . " ";
    }
?>