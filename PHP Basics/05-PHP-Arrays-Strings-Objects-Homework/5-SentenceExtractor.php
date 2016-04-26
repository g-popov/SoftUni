<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>Sentence Extractor</title>
    </head>
    <body>
        <form method="post" action="">
            <label for="text">Text:</label><br />
            <textarea name="text" id="text"></textarea><br />
            <label for="word">Word:</label><br />
            <input type="text" name="word" id="word" /><br />
            <input type="submit" />
        </form>
        <?php 
        if (isset($_POST['text'])) :
            $text = $_POST['text'];
            $word = $_POST['word'];
            $pattern ='/[^\.\?!]+[\.|!|\?]/';
            preg_match_all($pattern, $text, $matches);
            foreach ($matches[0] as $sentence) :
                $sentence = trim($sentence);
                if (preg_match('/[^\w]is[^\w]/', $sentence)) : ?>
                    <p><?= htmlspecialchars($sentence) ?></p>
        <?php 
                endif;    
            endforeach;
        endif;
        ?>
    </body>
</html>