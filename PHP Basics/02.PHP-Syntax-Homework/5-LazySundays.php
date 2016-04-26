<?php

$month = (int)date("m");
$year = (int)date("Y");
$monthLength = cal_days_in_month(CAL_GREGORIAN, $month, $year);
for ($i=1; $i <= $monthLength; $i++) { 
	$day = $i;
    $currentDate = new DateTime();
    $currentDate->setDate($year, $month, $day);
    $dayOfWeek = date("N", $currentDate -> getTimestamp());
    if ($dayOfWeek == 7) {
        echo $currentDate->format('jS F, Y') . "\n";
    }
}

?>