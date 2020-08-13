$(document).ready(function () {
    regex();
}); 

function regex() {
    var str = "Visit W3Schools";
    var patt = /w3schools/i;
    console.log(str.match(patt));
}

function loopsPractice(arr) {
    console.log('do, while');
    var i = arr.length - 1;
    do {
        console.log(arr[i]);
        i--;
    } while (i >= 0);

    console.log('while');
    var i = arr.length - 1;
    while (i >= 0) {
        console.log(arr[i]);
        i--;
    }
}

function checkArguments(num1, num2) {
    if (arguments.length > 1) {
        console.log(arguments);
    }
}

var xmlHttpCall = () => {
    let request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        console.log(this.readyState, ': ' + this.status + ' (' + this.statusText + ')');
        if (this.readyState == 4 && this.status == 200)
            console.log(JSON.parse(this.responseText));
    }
    request.open('GET', 'https://jsonmock.hackerrank.com/api/stocks?page=1');
    request.send();
}

function ajaxCall() {
    $.ajax({
        method: 'GET',
        url: 'https://jsonmock.hackerrank.com/api/stohhcks?page=1',
        dataType: 'json',
        success: ajaxSuccess,
        error: ajaxFailure
    });
}

function ajaxSuccess(data) {
    console.log(data);
}

function ajaxFailure() {
    throw 'ajax failed';
}

var exceptionHandling = (para) => {
    try {
        var x = 3;
        if (typeof para == 'string' && para.includes('s'))
            document.writeln(`yes ${x}`);
        else if (isNaN(para))
            document.writeln('not a number');
        else
            document.writeln(para / 1); 
    }
    catch (ex) {
        document.writeln(ex);
        throw 'another not s';
    }
    finally {
        document.writeln('done');
    }
}

function factorial(x) {
    var fact = 1;
    for (var i = x; i > 0; i--) {
        fact *= i;
    }
    console.log(fact);
}

function vowelsAndConsonants(s) {
    [...s].forEach(c => 'aeiou'.includes(c) ?
        console.log(c) : null);
    [...s].forEach(c => 'aeiou'.includes(c) ?
        null : console.log(c));
}