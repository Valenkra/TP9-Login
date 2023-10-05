// Write your JavaScript code.

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

    console.log(arguments);
    console.log(arguments.length);
    console.log(temp);
    if(temp != arguments.length){
        alert(`Falta información, por favor rellená todos los inputs necesarios.`);
        return false;
    }else{
        return true;
    }
}
