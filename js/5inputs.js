//var number1, number2, number3, number4, number5;
//function getNumbers() {
//    number1 = parseInt(document.getElementById('n1').value);
//    number2 = parseInt(document.getElementById('n2').value);
//    number3 = parseInt(document.getElementById('n3').value);
//    number4 = parseInt(document.getElementById('n4').value);
//    number5 = parseInt(document.getElementById('n5').value);

//}

//function findMax() {
//    getNumbers();
//    var maxResult = Math.max(number1, number2, number3, number4, number5);
//    document.getElementById('anotherbox').innerHTML = "The Max Number is " + maxResult;
//}
//function findMin() {
//    getNumbers();
//    var minResult = Math.min(number1, number2, number3, number4, number5);
//    document.getElementById('anotherbox').innerHTML = "The Min Number is " + minResult;
//}
//function findMean() {
//    getNumbers();
//    var meanResult = (number1 + number2 + number3 + number4 + number5) / 5;
//    document.getElementById('anotherbox').innerHTML = "The Mean is " + meanResult;
//}
//function findSum() {
//    getNumbers();
//    var sumResult = number1 + number2 + number3 + number4 + number5;
//    document.getElementById('anotherbox').innerHTML = "The Sum is " + sumResult;
//}
//function findProduct() {
//    getNumbers();
//    var productResult = number1 * number2 * number3 * number4 * number5;
//    document.getElementById('anotherbox').innerHTML = "The Product is " + productResult;
//}




//
//

//
//var number1, number2, number3, number4, number5;
//function getNumbers() {
//    number1 = parseInt(document.getElementById('n1').value);
//    number2 = parseInt(document.getElementById('n2').value);
//    number3 = parseInt(document.getElementById('n3').value);
//    number4 = parseInt(document.getElementById('n4').value);
//    number5 = parseInt(document.getElementById('n5').value);

    $('document').ready(function () {
        var number1, number2, number3, number4, number5;
        var array = [];
        function getNumbers() {
             number1 = parseInt($('#n1').val());
             number2 = parseInt($('#n2').val());
             number3 = parseInt($('#n3').val());
             number4 = parseInt($('#n4').val());
             number5 = parseInt($('#n5').val());
        };


        //if(n1 === "" || n2 === "" || n3 === "" || n4 === "" || n5 === ""){
        //    alert("5 numbers have not been entered.  Would you like to continue anyway?");
        //};


        $('#maxbtn').click(function () {
            getNumbers();
            var maxResult = Math.max(number1, number2, number3, number4, number5);
            $('#anotherbox').text("The Max Number is " + maxResult);
        });

        $('#minbtn').click(function () {
            getNumbers();
            var minResult = Math.min(number1, number2, number3, number4, number5);
            $('#anotherbox').text("The Min Number is " + minResult);
        });

        $('#meanbtn').click(function () {
            getNumbers();
            var meanResult = (number1 + number2 + number3 + number4 + number5) / 5;
            $('#anotherbox').text("The Mean is " + meanResult);
        });

        $('#sumbtn').click(function () {
            getNumbers();
            var sumResult = number1 + number2 + number3 + number4 + number5;
            $('#anotherbox').text("The Sum is " + sumResult);
        });

        $('#productbtn').click(function () {
            getNumbers();
            var productResult = number1 * number2 * number3 * number4 * number5;
            $('#anotherbox').text("The Product is " + productResult);
        });

///End brackets below to close off document ready
    })
