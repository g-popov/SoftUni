<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>Annual Expenses</title>
        <style>
            table, th, td {
                border: 1px solid black;
            }
        </style>
    </head>
    <body>
        <form method="get" action="">
            <label for="years">Enter number of years:</label>
            <input type="number" name="yearsCount" id="years" />
            <input type="submit" value="Show costs" />
        </form>
        <br />
        <?php
        if (isset($_GET['yearsCount'])) :
            $yearsCount = htmlspecialchars($_GET['yearsCount']);
        ?>
        <table>
            <thead>
                <tr>
                    <th>Year</th>
                    <?php 
                    for ($i=1; $i <= 12 ; $i++) : 
                        $month = date("F", mktime(0 , 0, 0, $i));
                    ?>
                    <th><?=$month?></th>
                    <?php endfor; ?>
                    <th>Total:</th>
                </tr>
            </thead>
            <tbody>
            <?php 
            $currentYear = date("Y");
            for ($i= $currentYear; $i > $currentYear - $yearsCount; $i--) :
            ?> 
                <tr>
                    <td><?=$i?></td>
                    <?php
                    $annualSum = 0;
                    for ($j=0; $j < 12; $j++) : 
                        $expense = rand(0, 999);
                        $annualSum += $expense;
                    ?>
                        <td><?=$expense?></td>
                    <?php endfor; ?>
                    <td><?=$annualSum?></td>
                </tr>
            <?php endfor; ?>
            </tbody>
        </table>
        <?php endif; ?>
    </body>
</html>