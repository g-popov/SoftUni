<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>CV Generator</title>
        <script src="addRemoveFields.js" type="text/javascript"></script>
    </head>
    <body>
        <form method="post" action="CVGenerator.php">
            <fieldset>
                <legend>Personal Information</legend>
                <input type="text" name="fname" placeholder="First Name" required="required"/><br>
                <input type="text" name="lname" placeholder="Last Name"  required="required" /><br>
                <input type="email" name="mail" placeholder="Email" required="required" /><br>
                <input type="tel" name="phone" placeholder="Phone Number" required="required" /><br>
                <label for="f">Female</label>
                <input type="radio" name="gender" id="f" value="Female" />
                <label for="m">Male</label>
                <input type="radio" name="gender" id="m" value="Male" /><br>
                <label for="bdate">Birth Date</label><br>
                <input type="date" name="bdate" id="bdate" /><br>
                <label for="nation">Nationality</label><br>
                <select name="nation" id="nation">
                    <option value="Bulgarian">Bulgarian</option>
                    <option value="Serbian">Serbian</option>
                    <option value="Greek">Greek</option>
                    <option value="Romanian">Romanian</option>
                </select>
            </fieldset>
            <fieldset>
                <legend>Last Work Position</legend>
                <label for="company">Company Name</label>
                <input type="text" name="company" id="company" required="required" /><br>
                <label for="from">From</label>
                <input type="date" name="from" id="from" /><br>
                <label for="to">To</label>
                <input type="date" name="to" id="to" />
            </fieldset>
            <fieldset>
                <legend>Computer Skills</legend>
                <label>Programming Languages</label><br>
                <div id="progrLanguages">
                    <script>addProgLang();</script>
                </div>
                <input type="button" value="Remove Language" onclick="removeProgLang()"/>
                <input type="button" value="Add Language" onclick="addProgLang()"/>
            </fieldset>
            <fieldset>
                <legend>Other Skills</legend>
                <label>Languages</label>
                <div id="languages">
                    <script>addLanguage();</script>
                </div>
                <input type="button" value="Remove Language" onclick="removeLanguage()"/>
                <input type="button" value="Add Language" onclick="addLanguage()" /><br>
                <label>Driver's Licence</label><br>
                <label for="b">B</label>
                <input type="checkbox" name="licence[]" value="B" id="b" />
                <label for="a">A</label>
                <input type="checkbox" name="licence[]" value="A" id="a" />
                <label for="c">C</label>
                <input type="checkbox" name="licence[]" value="C" id="c" />
            </fieldset>
            <input type="submit" name="submit" value="Generate CV" />
        </form>
    </body>
</html>