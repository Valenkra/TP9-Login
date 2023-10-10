function checkStringInput(){
    let inputs = []
    let temp = 0;

    for (let index = 0; index < arguments.length; index++) {
        inputs.push(document.getElementById(arguments[index]).value)
    }

    for (let index = 0; index < inputs.length; index++) {
        if(!/\S/.test(inputs[index].toString())){
            temp -= 1;
        }else{
            temp += 1;
        }
    }

    if(temp != arguments.length){
        alert(`Falta información, por favor rellená todos los inputs necesarios.`);
        return false;
    }else{
        return true;
    }
}




function showSignMessage(sms){
    let sayings = ["Se ha creado tu cuenta satisfactoriamente", "El nombre de usuario no es válido", 
    "Ya hay una cuenta con ese email", "Los datos son incorrectos o ya fueron utilizados en otra cuenta"];
    const resultado = document.getElementById("resultado");
    var index = document.getElementById("ViewBag.showSMS").value;
    let msg = '@TempData["show"]';
    resultado.innerHTML = sms;
    sms = sayings[index];
    alert(msg);
    alert(index);
}

let sms = "-";

if(document.body.contains(document.getElementById("sign-up-h1"))){
    showSignMessage(sms);
    alert("fuck");
}