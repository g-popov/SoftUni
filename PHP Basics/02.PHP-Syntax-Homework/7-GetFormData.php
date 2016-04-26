<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Form Data</title>
    <style>
        form {
            width: 195px;
        }
    </style>
</head>
<body>
    <form method="get">
        <input type="text" name="name" placeholder="Name..." />
        <input type="text" name="age" placeholder="Age..." />
        <div>
            <input type="radio" name="gender" id="male" value="male" />
            <label for="male">Male</label>
        </div>
        <div>
            <input type="radio" name="gender" id="female" value="female" />
            <label for="female">Female</label>
        </div>
        <input type="submit" name="submit" />
    </form>
        
    <?php if (isset($_GET["submit"])) { ?>
    
    <p>My name is <?php echo htmlentities($_GET['name']) ?>. I am <?php echo htmlentities($_GET['age']) ?> years old. I am <?php echo htmlentities($_GET['gender']) ?>.</p>
    
    <?php } ?>
</body>
</html>