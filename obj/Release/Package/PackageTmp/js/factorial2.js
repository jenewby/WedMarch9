function factor() {
    document.getElementById('display5').innerHTML = "";

    var input = parseInt(document.getElementById('input').value);
    var total = 1;
    if (input > 300) {
        alert("number too high!  Choose a lower number.");
        document.getElementById('input').value = "";
    } else {
        for (i = 1; i <= input; i++) {
            if (i < input) {
                document.getElementById('display5').innerHTML += i + " x ";
            } else {
                document.getElementById('display5').innerHTML += i + " = ";
            };

            total *= i;
        };
        document.getElementById('display5').innerHTML += total;
    }
   
};
