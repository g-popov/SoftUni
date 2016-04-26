<?php

function sumNumbers($firstNumber, $secondNumber) {
    $sum = $firstNumber + $secondNumber;
    echo '$firstnumber + $secondNumber = ' . "$firstNumber + $secondNumber = " . number_format($sum, 2, '.', '') . "\n";
}

$firstNumber = 2;
$secondNumber = 5;
sumNumbers($firstNumber, $secondNumber);

$firstNumber = 1.567808;
$secondNumber = 0.356;
sumNumbers($firstNumber, $secondNumber);

$firstNumber = 1234.5678;
$secondNumber = 333;
sumNumbers($firstNumber, $secondNumber);

?>
