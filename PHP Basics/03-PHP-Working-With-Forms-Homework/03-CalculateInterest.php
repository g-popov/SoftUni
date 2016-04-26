<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>Calculate Interest</title>
    </head>
    <body>
        <form method="get" action="">
            <label for="amount">Enter Amount</label>
            <input type="text" name="amount" id="amount" /><br>
            <input type="radio" name="currency" value="usd" />USD
            <input type="radio" name="currency" value="eur" />EUR
            <input type="radio" name="currency" value="bgn" />BGN
            <br>
            <label for="interest">Compound Interest Amount</label>
            <input type="text" name="interest" id="interest" /><br>
            <select name="period">
                <option value="6">6 Months</option>
                <option value="12">1 Year</option>
                <option value="24">2 Years</option>
                <option value="60">5 Years</option>
            </select>             
            <input type="submit" value="Caluclate" />
        </form>
        
        <?php
        if (isset($_GET['amount'])) {
            $amount = htmlentities($_GET['amount']);
            $interest = htmlentities($_GET['interest']);
            $months = htmlentities($_GET['period']);
            $resultingSum = $amount * pow((1 + $interest / 100 / 12), $months);
            $roundedSum = number_format((float)$resultingSum, 2, '.', '');
            switch ($_GET['currency']) {
                case 'usd': echo "$ $roundedSum"; break;
                case 'eur': echo "&euro; $roundedSum"; break;
                case 'bgn': echo "$roundedSum лв."; break;
            } 
        }
        ?>
    </body>
</html>