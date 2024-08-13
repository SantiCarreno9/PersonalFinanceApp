//const checkbox = document.getElementById('allCheckbox');
//const deleteButton = document.getElementById('deleteButton');

//function onTransactionSelected(element) {
//    if (element.checked) {
//        deleteButton.disabled = false;
//        element.parentelement.parentelement.classList.add("active");
//    }        
//    else {
//        element.parentelement.parentelement.classList.remove("active");
//        const elements = document.getElementsByClassName("items-toggle");        
//        for (let i = 0; i < elements.length; i++) {
//            if (elements[i].checked) {
//                deleteButton.disabled = false;
//                return;
//            }                        
//        }
//        deleteButton.disabled = true;
//    }
//}

//checkbox.addEventListener('change', (event) => {
//    const elements = document.getElementsByClassName("items-toggle");
//    const e = new Event('change');
//    for (let i = 0; i < elements.length; i++) {
//        elements[i].checked = event.currentTarget.checked;
//        elements[i].dispatchEvent(new Event('change')/*e*/);
//    }
//});
