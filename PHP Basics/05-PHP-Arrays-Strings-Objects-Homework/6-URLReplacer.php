<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>URL Replacer</title>
    </head>
    <body>
        <form method="post" action="">
            <label for="text">Text:</label><br />
            <textarea name="text" id="text"></textarea><br />
            <input type="submit" />
        </form>
        <?php
        if (isset($_POST['text'])) :
            $text = $_POST['text'];
            $pattern = '/<a href="([^>]+)">([^<]+)<\/a>/';
            $replacement = '[URL=\1]\2[/URL]';
            $result = preg_replace($pattern, $replacement, $text); ?>
            <p><?= htmlspecialchars($result) ?></p>
        <?php endif; ?>
    </body>
</html>