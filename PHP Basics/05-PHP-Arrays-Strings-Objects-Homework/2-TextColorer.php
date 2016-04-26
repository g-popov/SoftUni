<!DOCTYPE html>
<html>
<head>
	<meta charset="UTF-8" />
	<title>Coloring Texts</title>
</head>
<body>
	<form method="get" action="">
		<input type="text" name="inputStr" />
		<input type="submit" value="Color text" />
	</form>
	<?php
	if(isset($_GET['inputStr'])) :
		$str = $_GET['inputStr'];
  		for ($i = 0; $i < strlen($str); $i++) :
    		$char = $str[$i];
    		$charCode = ord($char);
            if ($charCode % 2 ==0) : ?>
				<span style="color:red"><?=$char?> </span>
            <?php else : ?>
				<span style="color:blue"><?=$char?> </span>
            <?php endif;
        endfor;
	endif; 
	?>
</body>
</html>
