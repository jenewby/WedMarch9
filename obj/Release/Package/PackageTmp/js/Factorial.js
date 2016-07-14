function factor() {
    var input = parseInt(document.getElementById('input').value);
    var total = 1;

    for (i = 1; i <= input; i++) {
        total *= i;
    };
    document.getElementById('display').innerHTML = total;
    alert("whats wrong");
};
