const PAGE_URL = 'https://localhost:5001';

async function getCategories() {
    let response = await fetch(PAGE_URL + '/Categories/OnGet', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => response.json())
    .then(data => data);

    return response;
}

async function getTypes(id = '') {
    let url = id.length > 0 ? `/Types/OnGet?id='${id}'` : '/Types/OnGet';
    let results = await fetch(PAGE_URL + url, {
        melhod: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => response.json())
    .then(data => data)
    .catch(error => {
        renderErrorMessage();
        console.error(error);
        return;
    });
    
    return results;
}

async function getSizes() {
    let results = await fetch(PAGE_URL + '/Sizes/OnGet', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => response.json())
    .then(data => data)
    .catch(error => {
        renderErrorMessage();
        console.error(error);
        return;
    });

    if(results?.code != 200) {
        console.error(results);
    }

    return results;
}

async function renderCategories() {
    let categoryElement = document.getElementById('product-category');
    let data = await getCategories();

    if(data.length > 0) {
        data.forEach(item => {
            let option = document.createElement('option');
            option.value = item.id;
            option.textContent = item.name;
            categoryElement.appendChild(option);
        });
    }

    categoryElement.addEventListener('change', () => renderTypes(categoryElement.value));
}

async function renderTypes(id = '') {
    let typeElement = document.getElementById('product-type');
    let results = await getTypes(id);

    if(results.length > 0) {

        results.forEach(item => {
            let option = document.createElement('option');
            option.value = item.id;
            option.textContent = item.name;
            typeElement.appendChild(option);
        });
    } else {
        for(let i = 1; i < typeElement.children.length; i++) {
            typeElement.removeChild(typeElement.children[i]);
        }
    }
}

async function renderSizes() {
    let sizeElement = document.getElementById('product-size');
    let data = await getSizes();

    if(data.length > 0) {
        data.forEach(item => {
            let option = document.createElement('option');
            option.value = item.id;
            option.textContent = item.name;
            sizeElement.appendChild(option);
        });
    }
}

function renderErrorMessage(message = 'An error occurred while processing your request, see logs.') {
    let errorElement = document.getElementById('page-error-content');
    let errorMessage = document.createElement('div');
    errorMessage.classList.add('alert', 'alert-danger');
    errorMessage.textContent = message;
    errorElement.appendChild(errorMessage);
    
    setTimeout(() => {
        errorMessage.remove();
    }, 3000);
}

(document.onload = () => {
    renderCategories();
    renderSizes();
})();