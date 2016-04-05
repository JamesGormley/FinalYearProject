
<?php 
        $db = mysql_connect('localhost','root', '') or die('Could not connect: ' . mysql_error()); 
        mysql_select_db('fyp') or die('Could not select database');
 
        // Strings must be escaped to prevent SQL injection attack. 
        $name = mysql_real_escape_string($_GET['name'], $db); 
        $score = mysql_real_escape_string($_GET['score'], $db); 
 
		// Send variables for the MySQL database class. 
		$query = "insert into highscores values (NULL, '$name', '$score');"; 
		$result = mysql_query($query) or die('Query failed: ' . mysql_error()); 
        
?>
