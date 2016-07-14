//if string.length a equals string.length b

// var length = document.getElementById("magicWord").length; // possible parseInt() needed

function start() {
    var entry = document.getElementById("magicWord").value;
    var db = parseInt(entry);

    var reverse = entry.split("").reverse().join("");
    //alert(reverse);;

    if (entry === "") {
        alert("Umm.  You didn't enter anything?");
    }
   else if (entry.length === 1 && isNaN(db) === true) {
        alert("Seriously?!  One letter?   I need at least 3.");
    }
   else if (entry.length === 2) {
        alert("Sorry.  Your word is TOO short!  Enter something longer.");
    }

    else if (isNaN(db) === false) {
        alert("Enter a word, not a number!  Pay attention.");
    }

    else if (entry === reverse) {

        document.getElementById("resultspali").innerHTML = "Palindromiousness!!! " + entry + " is a Palindrome!";
    }
    else {

        document.getElementById("resultspali").innerHTML = "Not a Palindrome dude.  Bummer.";
    };
}