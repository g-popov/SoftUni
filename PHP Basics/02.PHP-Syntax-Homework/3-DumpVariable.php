<?php

function variableType($value) {
    if (is_numeric($value)) {
        echo var_dump($value);
    } else {
        echo gettype($value) . "\n";
    }
}

$value = "hello";
variableType($value);

$value = 15;
variableType($value);

$value = 1.234;
variableType($value);

$value = array(1,2,3);
variableType($value);

$value = (object)[2,34];
variableType($value);

?>