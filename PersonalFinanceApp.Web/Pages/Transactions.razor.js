const checkbox = document.getElementById('allCheckbox')

checkbox.addEventListener('change', (event) => {
    const elements = document.getElementsByClassName("items-toggle");
    const e = new Event('change');
    for (let i = 0; i < elements.length; i++) {
        elements[i].checked = event.currentTarget.checked;
        elements[i].dispatchEvent(new Event('change')/*e*/);
    }    
});