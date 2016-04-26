<?php
function sumDigits($value) {
    $sum = 0;
    for ($i=0; $i < strlen($value); $i++) { 
        $digit = intval($value[$i]);
        $sum += $digit;
    }
    return $sum;
} 
?>

<!DOCTYPE html>
<html>
<head>
	<meta charset="UTF-8" />
	<title>Sum of Digits</title>
	<style>
	    table, th, td {
	        border: 1px solid black;
	    }
	</style>
</head>
<body>
	<form method="get" action="">
		<label for="values">Input string:</label>
		<input type="text" name="inputValues" id="values" />
		<input type="submit" />
	</form>
	<?php
	if(isset($_GET['inputValues'])) :
		$str = htmlspecialchars($_GET['inputValues']);
		$arr = explode(', ', $str);
	?>
		<table>
		<?php
		foreach ($arr as $value):
			if (!is_numeric($value)):
				$result = "I cannot sum that";
            else :
                $number = $value * 1;
                if (!is_integer($number)) :
                    $result = "I cannot sum that";
                else :
                    $result = sumDigits($value);
                endif;
            endif; ?>
            <tr>
                <td><?=$value?></td>
                <td><?=$result?></td>
            </tr>    
		<?php endforeach; ?>
		</table>
	<?php
	endif;
	?>
</body>
</html>