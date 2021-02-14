
<?php

if($_SERVER['HTTP_X_FORWARDED_FOR']!='91.108.6.94')
	exit;


$bot_token_seller = "https://api.telegram.org/bot". 'token';
$bot_chatID_seller = "1092318983";
$send_text_seller = $bot_token_seller . '/sendMessage?chat_id=' . $bot_chatID_seller . '&parse_mode=Markdown&text=';
$dbconn = pg_connect("host=localhost dbname=test user=pi password=pi port=5432") or die("failed to connect db".pg_last_error());

function set_webhook($url) {
	global $bot_token_seller;
	$response = file_get_contents($bot_token_seller . "/setwebhook?url=" . $url);
	echo $response;
}

function send($msg) {
	global $send_text_seller;
	$response = file_get_contents($send_text_seller.$msg);
}

function seller_response($contacts) {
	for($i=0;$i<pg_num_rows($contacts);$i++) {
		$final_msg.=pg_fetch_row($contacts,$i)[0]."\n";	
	}
	send(urlencode($final_msg));
}



function check($chatID,$msg) {
	global $dbconn;
	if($dbconn) {
		echo "db connected to " . pg_dbname($dbconn);
		$res = pg_query($dbconn, "SELECT chatid FROM customers WHERE chatid=".$chatID);
		if(!!$res) { 

			$row = pg_fetch_row($res);
			$chatid_dt= $row[0];

			if($chatid_dt==NULL) {
				$res = pg_query($dbconn, "UPDATE customers SET chatid=".$chatID." WHERE code='".$msg."'"); 
				return false;
			}
			global $bot_chatID_seller;
			if($chatid_dt==$bot_chatID_seller) {
				seller_response(pg_query($dbconn,"SELECT contact FROM customers"));
				return false;
			}
			return true;
		}
	}
	return false;
}


function customer_response($msg) {
}




set_webhook("https://xe98pjja26gg.p50.rt3.io");

$update = file_get_contents("php://input");
$chatID_customer = json_decode($update,TRUE)["message"]["chat"]["id"];
$msg=json_decode($update,TRUE)["message"]["text"];

if(!empty($update)) {
	if(check($chatID_customer,$msg)) {
		$res=pg_query($dbconn, "SELECT contact FROM customers WHERE chatid=".$chatID_customer);
		$msg_to_send=("Zpráva od: ".pg_fetch_row($res)[0]."\n"."*".$msg."*");
		send(urlencode($msg_to_send));
	}
}







//echo "<br>";
//if (file_put_contents("json.json", json_encode($update)))
//	echo "json saved";
//else
//	echo "failed to save json";
//echo "<br>";



pg_close($dbconn);

?>
