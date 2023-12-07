<?php

$dbServerName = "u210399.gluwebsite.nl";
$dbName = "u120399_Overgrown";
$dbUsername = "u120399_Overgrown"; 
$dbPassword = "OVergrown1";

$conn = new PDO("mysql:host=$dbServerName;dbname=$dbName", $dbUsername, $dbPassword);

$conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
//echo "Connected successfully";
?>