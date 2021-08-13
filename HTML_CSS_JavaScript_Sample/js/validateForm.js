function validateForm(form) {
    if (form.elements[0].value == ""){
         alert("Please fill in your first name.");
         form.elements[0].focus();
         return false;
    }
    if (form.elements[1].value == ""){
         alert("Please fill in your last name.");
         form.elements[1].focus();
         return false;
    }
    if (form.elements[2].value == ""){
         alert("Please fill in your Address.");
         form.elements[2].focus();
         return false;
    }
    if (form.elements[3].value == ""){
         alert("Please fill in your city.");
         form.elements[3].focus();
         return false;
    }
    if (form.elements[4].value == ""){
         alert("Please select your province.");
         form.elements[4].focus();
         return false;
    }
    if (form.elements[5].value == ""){
         alert("Please fill in your postal code.");
         form.elements[5].focus();
         return false;
    }
    if (form.elements[6].value == ""){
         alert("Please fill in your email address.");
         form.elements[6].focus();
         return false;
    }
    if (form.elements[7].value == ""){
         alert("Please fill in your password.");
         form.elements[7].focus();
         return false;
    }
    if (form.elements[8].value == ""){
         alert("Please confirm your password.");
         form.elements[8].focus();
         return false;
    }
  
    /*if (form.elements[10].value == ""){
        alert("Please select your gender.");
        form.elements[10].focus();
        return false;
    }
    if (form.elements[11].value == ""){
        alert("Please select your language.");
        form.elements[11].focus();
        return false;
    }
    if (form.elements[12].value == ""){
        alert("Please input your comments.");
        form.elements[12].focus();
        return false;
    }*/
    var gender = document.myForm.gender;
    var language = document.myForm.language;
    var comments = document.myForm.comments;
    
    if (gender.value == "") {
        alert("Please select your gender.");
        return false;
    }
//--------  validate checkbox element ----------
	var checkBox = new Array();  // or var checkBox = [];
	for (var i=0;i<language.length;i++){
		checkBox[i] = language[i].checked;
	}
	if (checkBox.indexOf(true) == -1) {
		alert("Please select your language.");
		return false;
	}
//---------------------------------------------------
    if (comments.value == "") {
        alert("Please tell us about yourself.");
		comments.focus();
        return false;
    }
//----- validate postal code using regular expression -----
    var postal_code = document.getElementById("postal_code").value;   // var postal_code = document.myForm.postal_code.value;
    var patt = /^[A-Z]\d[A-Z]?\d[A-Z]\d$/i;
    var res = patt.test(postal_code);

   if (!res) {
       alert ("Please input valid postal code");
       return false;
   } 


}
