<!DOCTYPE html>
<html>
<head>
	<meta charset="UTF-8" />
	<title>Word Mapping</title>
</head>
<body border="1">
	<form method="get" action="">
		<input type="text" name="inputStr" />
		<input type="submit" value="Count words" />
	</form>
	<?php
	if(isset($_GET['inputStr'])) : ?>
		<table border="1">
	<?php	
		$str = $_GET['inputStr'];
		$str = strtolower($str);
		$arr = str_word_count($str, 1);
		$wordCount = array_count_values($arr);
		foreach ($wordCount as $word => $count) : ?>
			<tr>
				<td><?=htmlspecialchars($word)?></td>
				<td><?=$count?></td>
			</tr>
		<?php endforeach; ?>
		</table>
	<?php endif; ?>
</body>
</html>