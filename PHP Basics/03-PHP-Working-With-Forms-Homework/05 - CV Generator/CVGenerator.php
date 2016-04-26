<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>CV</title>
        <link rel="stylesheet" href="style.css" />
    </head>
    <body>
        <?php
        if (isset($_POST['submit'])) {
            if (!ctype_alpha($_POST['fname']) || strlen($_POST['fname']) < 2 || strlen($_POST['fname']) > 20) {
                echo "<p>First name should consist of letters between 2 and 20 symbols.</p>";
            }
            else { 
                if (!ctype_alpha($_POST['lname']) || strlen($_POST['lname']) < 2 || strlen($_POST['lname']) > 20) {
                    echo "<p>Last name should consist of letters only, between 2 and 20 symbols.</p>";
                
                }
                else {
                    if (!filter_var($_POST['mail'], FILTER_VALIDATE_EMAIL)) {
                        echo "<p>Email should consist of letters and numbers only, with only one \"@\" and \".\".</p>";
                    }
                    else {
                        $phoneDigits = preg_replace('/[]\+\s\-]/', '', $_POST['phone']);
                        if (!ctype_digit($phoneDigits)) {
                            echo "<p>Phone number should consist of numbers and \"+\", \"-\", \" \".</p>";
                        } 
                        else {
                            if (!ctype_alnum($_POST['company']) || strlen($_POST['company']) < 2 || strlen($_POST['company']) > 20) {
                                echo "<p>Company name should consist of letters and numbers only, between 2 and 20 symbols.</p>";
                            }
                            else {
                                for ($i=0; $i < count($_POST['langs']); $i++) {
                                    $validLang = TRUE; 
                                    if (!ctype_alpha($_POST['langs'][$i]) || strlen($_POST['langs'][$i]) < 2 || strlen($_POST['langs'][$i]) > 20) {
                                        echo "<p>Language should consist of letters only,  between 2 and 20 symbols.</p>";
                                        $validLang = FALSE;
                                        break;
                                    }
                                }
                                if ($validLang) {
                                    include 'CV.php';
                                }
                            } 
                        }
                    }   
                }
            }
        }
        ?>
    </body>
</html>
    

