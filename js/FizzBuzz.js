
var fizzn1;
var fizzn2;
function compute() {
    fizzn1 = parseInt(document.getElementById('fizzn1').value);
    fizzn2 = parseInt(document.getElementById('fizzn2').value);
    for (var x = 1; x <= 100; x++) {
        if (x % fizzn1 === 0 && x % fizzn2 === 0) {
            document.getElementById("displayfb").innerHTML += "fizz buzz" + ", ";
        }
        else if (x % fizzn2 === 0) {
            document.getElementById("displayfb").innerHTML += "buzz" + ", ";
        }
        else if (x % fizzn1 === 0) {
            document.getElementById("displayfb").innerHTML += "fizz" + ", ";
        }
        else {
            document.getElementById("displayfb").innerHTML += x + ", ";
        }
    }
}

//Need to concatinate and probably create more variables to get this done.