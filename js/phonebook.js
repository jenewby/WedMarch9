var people = {};
var peopleAr = [];
function directoryData() {
    people.james = {
        firstName: "James",
        lastName: "Newby",
        phoneNumber: "(650) 777-7777",
        email: "james.newby@example.com"
    };

    people.olivia = {
        firstName: "Olivia",
        lastName: "Johnson",
        phoneNumber: "(650) 888-8888",
        email: "olivia.johson@example.com"
    };

    people.bob = {
        firstName: "Bob",
        lastName: "Costas",
        phoneNumber: "(650) 999-9999",
        email: "bob.costas@example.com"
    };

    people.mary = {
        firstName: "Mary",
        lastName: "Becker",
        phoneNumber: "(543) 555-5555",
        email: "mary.becker@example.com"
    };
    people.jhanine = {
        firstName: "Jhanine",
        lastName: "Trigo",
        phoneNumber: "(543) 555-5555",
        email: "miss.trigo@example.com"
    };
    people.todd = {
        firstName: "Todd",
        lastName: "Mitchell",
        phoneNumber: "(232) 567-5426",
        email: "todd.mitch@example.com"
    };
}


//generalSearch Revisiono


function generalSearch() {
    directoryData();
    var generalsearch = document.getElementById("generalsearch").value;

    var pickles = false;

    if (generalsearch === "") {
        document.getElementById("here").innerHTML = "No information entered";

    }
    else {

        for (var i in people) {
            if (people[i].lastName.toLowerCase().includes(generalsearch)) {
                pickles = true;
                printContact(i);
            }
            else if (people[i].firstName.toLowerCase().includes(generalsearch)) {
                pickles = true;
                printContact(i);
            }
            else if (people[i].phoneNumber.includes(generalsearch)) {
                pickles = true;
                printContact(i);
            }
            else if (people[i].email.toLowerCase().includes(generalsearch)) {
                pickles = true;
                printContact(i);
            }
        }
        if (pickles == false) {
            document.getElementById("here").innerHTML = "Contact not found";
        };
    }
}
//function printContact (i) { 
//    document.getElementById("here").innerHTML = people[i].firstName + "<br>" + people[i].lastName + "<br>" + people[i].phoneNumber + "<br>" + people[i].email ;


/*
text = "Blah blah blah blah blah blah Eric \
blah blah blah Eric blah blah Eric blah blah \
blah blah blah blah blah Eric";

console.log(text[0]);

var myName = "Eric";
var hits = [];

var generalsearch = document.getElementById("generalsearch").value;
    
    var pickles = false;
    for (var i in people)
    {
        if (people[i].lastName.toLowerCase().inlcudes(generalsearch))
        {
            pickles = true;
            printContact(i);
            }


for(var i = 0; i < generalsearch.length; i++) {
if (text[i] === generalsearch[0]) {
// If we find it, add characters up to
// the length of my name to the array
for(var j = i; j < (myName.length + i); j++) {
    hits.push(text[j]);
}
}
}

if (hits.length === 0) {
console.log("Your name wasn't found!");
} else {
console.log(hits);
}

*/
//generalSearch


/*    function generalSearch ()
    {
        var generalsearch = document.getElementById("generalsearch").value;
        
        var pickles = false;
        for (var i in people)
        {
            if (generalsearch.toLowerCase() === people[i].lastName.toLowerCase())
            {
                pickles = true;
                printContact(i);
            }
            else if (generalsearch.toLowerCase() === people[i].firstName.toLowerCase())
            {
                pickles = true;
                printContact(i);
            }        
            else if (generalsearch.toLowerCase() === people[i].phoneNumber)
            {
                pickles = true;
                printContact(i);
            }
            else if (generalsearch.toLowerCase() === people[i].email.toLowerCase())
            {
                pickles = true;
                printContact(i);
            }
        }
        if (pickles == false)
        {
            document.getElementById("here").innerHTML = "Contact not found";
        };
    } */
//function printContact (i) { 
//    document.getElementById("here").innerHTML = people[i].firstName + "<br>" + people[i].lastName + "<br>" + people[i].phoneNumber + "<br>" + people[i].email ;



//advSearch

function advSearch() {
    directoryData();
    var fname = document.getElementById("fname").value;
    var lname = document.getElementById("lname").value;
    var phonenumber = document.getElementById("phonenumber").value;
    var email = document.getElementById("email").value;

    /*      for (var i in people){
             if (lname.toLowerCase() === people[i].lastName.toLowerCase()){
                printContact();
             }
             else if (fname.toLowerCase() === people[i].firstName.toLowerCase()){
                printContact();
             }        
             else if (phonenumber.toLowerCase() === people[i].phoneNumber){
                printContact();
             }
             else if (email.toLowerCase() === people[i].email.toLowerCase()){
                printContact();
             }
        }; 
        
  */

    //declared flag so if result if called have no entry then no contact found message will appear
    var flag = false;
    if (lname === "" && fname === "" && phonenumber === "" && email === "") {
        document.getElementById("here").innerHTML = "No information entered";

    }
    else {
        //for (var i=0; i <people.length; i++){   < this only works if i put people into an array first.  
        for (var i in people) {
            if (lname !== "" && people[i].lastName.toLowerCase().includes(lname)) {
                flag = true;
                printContact(i);
            }
            else if (fname !== "" && people[i].firstName.toLowerCase().includes(fname)) {
                flag = true;
                printContact(i);
            }
            else if (phonenumber !== "" && people[i].phoneNumber.includes(phonenumber)) {
                flag = true;
                printContact(i);
            }
            else if (email !== "" && people[i].email.toLowerCase().includes(email)) {
                flag = true;
                printContact(i);

            }
        }
        if (flag == false) {
            document.getElementById("here").innerHTML = "Contact not found";
        }
    }
}

function printContact(i) {
    document.getElementById("here").innerHTML = "<br>" + people[i].firstName + "<br>" + people[i].lastName + "<br>" + people[i].phoneNumber + "<br>" + people[i].email;
}