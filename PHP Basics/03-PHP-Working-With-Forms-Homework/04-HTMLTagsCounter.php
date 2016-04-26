<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>HTML Tags Counter</title>
    </head>
    <body>
        <form method="post" action="">
            <label for="tag">Enter HTML tags:</label>
            <input type="text" name="tag" id="tag" />
            <input type="submit" />
        </form>
        <br>
        <?php
        if (isset($_POST['tag'])) {
            session_start();
            $tags = array('a', 'abbr', 'acronym', 'address', 'applet', 'area', 'article', 'aside', 'audio', 'b', 'base', 'basefont', 'bdi', 'bdo',
    'big', 'blockquote', 'body', 'br', 'button', 'canvas', 'caption', 'center', 'cite', 'code', 'col','colgroup', 'datalist','dd','del','details',
    'dfn','dialog','dir','div','dl','dt','em','embed', 'fieldset', 'figcaption', 'figure','font', 'footer', 'form','frame','frameset', 'head',
    'header','hgroup','h1','h2','h3','h4','h5','h6','hr','tml','i','iframe','img','input','ins','kbd','keygen','label','legend','li','link','main',
    'map','mark','menu','menuitem','meta','meter','nav','noframes','noscript','object','ol','optgroup','option','output','p','param','pre',
    'progress','q','rp','rt','ruby','s','samp','script','section','select','small','source','span','strike','strong','style', 'sub', 'summary', 
    'sup','table','tbody','td','textarea','tfoot','th','thead','time','title','tr','track','tt','u','ul','var','video', 'wbr');
           if (!isset($_SESSION['count'])) {
                $_SESSION['count'] = 0;
            } else {
                $input = htmlentities($_POST['tag']);
                if (in_array($input, $tags)) {
                    $_SESSION['count']++;
                    echo "Valid HTML tag!\r\nScore: ${_SESSION['count']}";
                } else {
                    echo "Invalid HTML tag!\r\nScore: ${_SESSION['count']}";
                }
                
            }
        }
        ?>
    </body>
</html>