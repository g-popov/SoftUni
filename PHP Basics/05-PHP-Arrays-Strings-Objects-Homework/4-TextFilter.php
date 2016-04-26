<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>TextFilter</title>
    </head>
    <body>
        <form method="post" action="">
            <label for="text">Text:</label><br />
            <textarea name="text" id="text"></textarea><br />
            <label for="banlist">Banlist:</label><br />
            <input type="text" name="banlist" id="banlist" /><br />
            <input type="submit" />
        </form>
        <?php
        if (isset($_POST['text'])) :
            $text = $_POST['text'];
            $banlist = explode(', ', $_POST['banlist']);
            foreach ($banlist as $word) {
                $replacer = str_repeat('*', strlen($word));
                $text = str_replace($word, $replacer, $text);
            } ?>
            <p><?= htmlspecialchars($text) ?></p>
        <?php    
        endif;
        ?>
    </body>
</html>