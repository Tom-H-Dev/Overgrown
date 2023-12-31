<?php
echo("jgojrgoer");
if (!isset($_POST["json"])){
    die("No json exits...");
}

$request = json_decode($_POST["json"]);

$response = new STDClass();

switch($request->action){
    case "create_account":
        CreateAccount($request);
        return;
    case "login_request":
        Login($request);
        return;
    case "logout_action":
        LogOut($request);
        return;   
    default:
        $response->serverMessage = "No valid server action";
        echo(json_encode($response));
}

function CreateAccount($request){
    global $response;
    require_once("Connect.php");
    //Email
    $stmt = $conn->prepare("SELECT id from users WHERE email = :email");
    $stmt->bindParam(":email", $input);
    $stmt->execute();
    if ($stmt->fetchColumn() > 0){
        $response->serverMessage = "EmailAlreadyExists";
        $response->errorMEssage = "Email already exists";
        echo(json_encode($response));
        return;     
    }

    //The username
    $stmt = $conn->prepare("SELECT id from users WHERE username = :username");
    $stmt->bindParam(":username", $input);
    $stmt->execute();
    if ($stmt->fetchColumn() > 0){
        $response->errorMEssage = "Username already exists";
        echo(json_encode($response));
        return;     
    }

    //Password
    $hash = password_hash($request->password, PASSWORD_DEFAULT);


    $response->serverMessage = "Succes";
    echo(json_encode($response));
}

function Login($request){
    global $response;
    require_once("Connect.php");
    $stmt = $conn->prepare("SELECT * from users WHERE email = :email");
    $stmt->bindParam(":email", $request->email);
    $stmt->execute();

    $row = $stmt->fetch(PDO:: FETCH_ASSOC);
    if ($row == false){
        $response->serverMessage = "Email_not_found";
        echo(json_encode($response));
        return;     
    }
    $id = $row["id"];
    if(!password_verify($request->password, $row["hash"])){
        $response->serverMessage = "WrongPassword";
        echo(json_encode($response));
        return; 
    }
    $token = GetRandomStringUniqid(32);
    $stmt = $conn->prepare("UPDATE users SET token = :token WHERE id = :id");
    $stmt->bindValue(":token", $token);
    $stmt->bindValue(":id", $id);
    $stmt->execute();
    $response->token = $token;
    $response->serverMessage = "Succes";
    echo(json_encode($response));
}

function GetRandomStringUniqid($length = 16){
    $string = uniqid(rand());
    $randomString = substr($string, 0, $length);
    return $randomString;
}


function LogOut($request){
    global $response;
    require_once("Connect.php");

    $stmt = $conn->prepare("SELECT * FROM users WHERE token = :token");
    $stmt->bindValue(":token", $request->token);
    $stmt->execute();
    $row = $stmt->fetch(PDO:: FETCH_ASSOC);
    if ($row == null){
        $response->serverMessage = "token not found";
        echo(json_encode($response));
        return;
    }
    $id = $row["id"];
    $stmt = $conn->prepare("UPDATE users SET token = null WHERE id = :id");
    $stmt->bindValue(":id", $id);
    $stmt->execute();

    $response->serverMessage = "Succes";
    echo(json_encode($response));
}
?>