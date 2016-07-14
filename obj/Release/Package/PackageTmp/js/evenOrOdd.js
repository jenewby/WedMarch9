
function solve() {
    var num1 = parseInt(document.getElementById("num1").value);
    if (num1 % 2 === 0) {
        document.getElementById("result").innerHTML = num1 + " is an even number";
    } else {

        document.getElementById("result").innerHTML = num1 + " is an odd number";
    }
}
