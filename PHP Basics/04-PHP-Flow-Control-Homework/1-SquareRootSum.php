<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>Square Root Sum</title>
        <style>
            table, th, td {
                border: 1px solid black;
            }
            tfoot td {
                font-weight: bold;
            }
        </style>
    </head>
    <body>
        <table>
            <thead>
                <tr>
                    <th>Number</th>
                    <th>Square</th>
                </tr>
            </thead>
            <tbody>
            <?php 
            $sum = 0;
            for ($i=0; $i <= 100; $i+=2) : 
                $sqRoot = round(sqrt($i), 2);
                $sum += $sqRoot;
            ?>
                <tr>
                    <td><?=$i?></td>
                    <td><?=$sqRoot?></td>
                </tr>
            <?php endfor; ?>
            </tbody>
            <tfoot>
                <tr>
                    <td>Total:</td>
                    <td><?=$sum?></td>
                </tr>
            </tfoot>
        </table>
    </body>
</html>