<?php
function buildList($arr) { 
    for ($i=0; $i < count($arr); $i++) : ?>
        <li><a href="#"><?=htmlspecialchars($arr[$i])?></a></li>
<?php 
    endfor;    
} 
?>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>Sidebar Builder</title>
        <link rel="stylesheet" href="3-SidebarBuilder.css" />
    </head>
    <body>
        <form method="get" action="">
            <label for="categories">Categories:</label>
            <input type="text" name="categories" id="categories" />
            <label for="tags">Tags:</label>
            <input type="text" name="tags" id="tags" />
            <label for="months">Months:</label>
            <input type="text" name="months" id="months" />
            <input type="submit" name="generate" value="Generate" />
        </form>
        <?php
        if (isset($_GET['generate'])) :
            $categories = explode(', ', $_GET['categories']);
            $tags = explode(', ', $_GET['tags']);
            $months = explode(', ', $_GET['months']); ?>
            <aside>
                <nav>
                    <ul>
                        <h1>Categories</h1>
                        <?php buildList($categories); ?>
                    </ul>
                </nav>
            </aside>
            <aside>
                <nav>
                    <ul>
                        <h1>Tags</h1>
                        <?php buildList($tags); ?>
                    </ul>
                </nav>
            </aside>
            <aside>
                <nav>
                    <ul>
                        <h1>Months</h1>
                        <?php buildList($months); ?>
                    </ul>
                </nav>
            </aside>
        <?php
        endif;
        ?>
    </body>
</html>