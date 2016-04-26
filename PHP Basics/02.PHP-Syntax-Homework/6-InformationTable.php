<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Information Table</title>
    <link rel="stylesheet" href="6-InformationTable.css" />
</head>
<body>
    <table>
        <?php
        function printTable($name, $phone, $age, $address) {
        ?>
            <tr>
                <td>Name</td>
                <td><?php echo $name ?></td>
            </tr>
            <tr>
                <td>Phone number</td>
                <td><?php echo $phone ?></td>
            </tr>
            <tr>
                <td>Age</td>
                <td><?php echo $age ?></td>
            </tr>
            <tr>
                <td>Address</td>
                <td><?php echo $address ?></td>
            </tr>
        <?php
        }
        printTable("Pesho", "0884-888-888", 67, "Suhata Reka");
        ?>
    </table>
</body>
</html>