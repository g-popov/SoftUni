<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>Rich People's Problems</title>
        <style>
            table, th, td {
                border: 1px solid black;
            }
        </style>
    </head>
    <body>
        <form method="get" action="">
            <label for="cars">Enter cars</label>
            <input type="text" name="cars" id="cars" />
            <input type="submit" value="Show result" />
        </form>
        <br />
        <?php
        if (isset($_GET['cars'])) : 
        ?>
        <table>
            <thead>
                <tr><th>Car</th><th>Color</th><th>Count</th></tr>
            </thead>
            <tbody>
            <?php
                $cars = explode(', ', htmlspecialchars($_GET['cars']));
                $colors = array('blue','red', 'black', 'yellow', 'silver');
                foreach ($cars as $car) :
                    $colorKey = array_rand($colors);
                    $color = $colors[$colorKey];
                    $count = rand(1, 5);
            ?>
                    <tr>
                        <td><?=$car?></td>
                        <td><?=$color?></td>
                        <td><?=$count?></td>
                    </tr>
            <?php endforeach; ?>
            </tbody>
        </table>
        <?php endif; ?>
    </body>
</html>