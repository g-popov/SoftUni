<?php

function nonRepeatingDigits($n) {
    $result = array();
     if ($n < 100) {
         echo "no\n";
     }
     else {
        if ($n > 999) {
            $n = 999;
        }
        for ($i=100; $i <= $n; $i++) { 
            $firstDigit = $i / 100 % 10;
            $secondDigit = $i / 10 % 10;
            $thirdDigit = $i % 10;
            if ($firstDigit != $secondDigit) {
                if ($firstDigit != $thirdDigit) {
                    if ($secondDigit != $thirdDigit) {
                        array_push($result, $i);
                    }
                }
            }
        }
        echo join(", ", $result) . "\n";
     }
}

$n = 1234;
nonRepeatingDigits($n);

$n = 145;
nonRepeatingDigits($n);

$n = 15;
nonRepeatingDigits($n);

$n = 247;
nonRepeatingDigits($n);

?>