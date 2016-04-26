<table>
    <thead>
        <tr>
            <th colspan="2">Personal Information</th>
        </tr>
    </thead>
    <tr>
        <td>First Name</td>
        <td><?php echo htmlentities($_POST['fname']); ?></td>
    </tr>
    <tr>
        <td>Last Name</td>
        <td><?php echo htmlentities($_POST['lname']); ?></td>
    </tr>
    <tr>
        <td>Email</td>
        <td><?php echo htmlentities($_POST['mail']); ?></td>
    </tr>
    <tr>
        <td>Phone Number</td>
        <td><?php echo htmlentities($_POST['phone']); ?></td>
    </tr>
    <tr>
        <td>Gender</td>
        <td><?php echo htmlentities($_POST['gender']); ?></td>
    </tr>
    <tr>
        <td>Birth Date</td>
        <td><?php echo htmlentities($_POST['bdate']); ?></td>
    </tr>
    <tr>
        <td>Nationality</td>
        <td><?php echo htmlentities($_POST['nation']); ?></td>
    </tr>
</table>
<br>
<table>
    <thead>
        <tr>
            <th colspan="2">Last Work Position</th>
        </tr>
    </thead>
    <tr>
        <td>Company Name</td>
        <td><?php echo htmlentities($_POST['company']); ?></td>
    </tr>
    <tr>
        <td>From</td>
        <td><?php echo htmlentities($_POST['from']); ?></td>
    </tr>
    <tr>
        <td>To</td>
        <td><?php echo htmlentities($_POST['to']); ?></td>
    </tr>
</table>
<br>
<table>
    <thead>
        <tr>
            <th colspan="2">Computer Skills</th>
        </tr>
    </thead>
    <tr>
        <td>Programming Languages</td>
        <td>
            <table>
                <thead>
                    <tr>
                        <th>Language</th>
                        <th>Skill Level</th>
                    </tr>
                </thead>
                <?php 
                for ($i=0; $i < count($_POST["progrLangs"]); $i++) { ?> 
                    <tr>
                        <td><?php echo htmlentities($_POST["progrLangs"][$i]); ?></td>
                        <td><?php echo htmlentities($_POST["levels"][$i]); ?></td>
                    </tr>
                <?php } ?>
            </table>
        </td>
    </tr>
</table>
<br>
<table>
    <thead>
        <tr>
            <th colspan="2">Other Skills</th>
        </tr>
    </thead>
    <tr>
        <td>Languages</td>
        <td>
            <table>
                <thead>
                    <tr>
                        <th>Language</th>
                        <th>Comprehension</th>
                        <th>Reading</th>
                        <th>Writing</th>
                    </tr>
                </thead>
                <?php 
                for ($i=0; $i < count($_POST["langs"]); $i++) { ?> 
                    <tr>
                        <td><?php echo htmlentities($_POST["langs"][$i]); ?></td>
                        <td><?php echo htmlentities($_POST["comprehension"][$i]); ?></td>
                        <td><?php echo htmlentities($_POST["reading"][$i]); ?></td>
                        <td><?php echo htmlentities($_POST["writing"][$i]); ?></td>
                    </tr>
                <?php } ?>
            </table>
        </td>
    </tr>
    <tr>
        <td>Driver's Licence</td>
        <td>
            <?php 
            echo implode(", ", $_POST['licence']);
            ?>
        </td>
    </tr>
</table>