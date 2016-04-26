function addProgLang() {
	var newDiv = document.createElement("div");
	newDiv.innerHTML = "<input type=\"text\" name=\"progrLangs[]\" />" +
                        "<select name=\"levels[]\">" + 
                        "<option value=\"Beginner\">Beginner</option>" + 
                        "<option value=\"Programmer\">Programmer</option>" + 
                        "<option value=\"Ninja\">Ninja</option>" + 
                        "</select>";
	document.getElementById("progrLanguages").appendChild(newDiv);
}

function removeProgLang() {
	var childrenLength = document.getElementById("progrLanguages").childNodes.length;
	var lastChild = document.getElementById("progrLanguages").childNodes[childrenLength - 1];
	document.getElementById("progrLanguages").removeChild(lastChild);
}

function addLanguage() {
	var newDiv = document.createElement("div");
	newDiv.innerHTML = "<input type=\"text\" name=\"langs[]\" />" +
                        "<select name=\"comprehension[]\" required=\"required\">" +
                            "<option selected disabled>-Comprehension-</option>" +
                            "<option value=\"Beginner\">Beginner</option>" +
                            "<option value=\"Intermediate\">Intermediate</option>" +
                            "<option value=\"Advanced\">Advanced</option>" +
                        "</select>" +
                        "<select name=\"reading[]\" required=\"required\">" +
                            "<option selected disabled>-Reading-</option>" +
                            "<option value=\"Beginner\">Beginner</option>" +
                            "<option value=\"Intermediate\">Intermediate</option>" +
                            "<option value=\"Advanced\">Advanced</option>" +
                        "</select>" +
                        "<select name=\"writing[]\" required=\"required\">" +
                            "<option selected disabled>-Writing-</option>" +
                            "<option value=\"Beginner\">Beginner</option>" +
                            "<option value=\"Intermediate\">Intermediate</option>" +
                            "<option value=\"Advanced\">Advanced</option>" +
                        "</select>";
    document.getElementById("languages").appendChild(newDiv);
}

function removeLanguage() {
	var childrenLength = document.getElementById("languages").childNodes.length;
	var lastChild = document.getElementById("languages").childNodes[childrenLength - 1];
	document.getElementById("languages").removeChild(lastChild);
}
