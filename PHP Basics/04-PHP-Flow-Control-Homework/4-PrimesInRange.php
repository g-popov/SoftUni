<?php function isPrime($number) {
	$result = true;
	if ($number < 2) {
		$result = false;
	}
	$maxDivider = round(sqrt($number));
	for ($i = 2; $i <= $maxDivider; $i++) {
		if ($number % $i == 0) {
			$result = false;
			break;
		}
	}
	return $result;
}
?>
<html>
<head>
	<meta charset="UTF-8" />
	<title>Primes in Range</title>
</head>
<body>
    <form method="get" action="">
        <label for="startInd">
        <input type="number" name="start" id="startInd" />
        <label for="endInd">
        <input type="number" name="end" id="endInd" />
        <input type="submit" name="submit"/>
    </form>
    <?php
	if (isset($_GET['submit'])) {
		$start = htmlspecialchars($_GET['start']);
		$end = htmlspecialchars($_GET['end']);
		for ($i = $start; $i <= $end; $i++) {
			if (isPrime($i)) {
				echo "<b>${i}</b>";
			}
			else {
				echo "$i";
			}
			if ($i < $end) {
				echo ", ";
			}
		}
	}
    ?>
</body>
</html>
