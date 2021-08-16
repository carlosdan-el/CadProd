const urlSearchParams = new URLSearchParams(window.location.search);
const params = Object.fromEntries(urlSearchParams.entries());
const PAGE_URL = 'https://localhost:5001';

async function getProducts() {
    let results = await fetch(PAGE_URL + '/Products/OnGet', {
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
    });

    return results;
}

async function getProductsById(id = '') {
    let results = await fetch(PAGE_URL + `/Products/OnGetById?id='${id}'`, {
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
    });

    return results;
}

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

async function getCategoriesView() {
    let response = await fetch(PAGE_URL + '/Categories/OnGetCategoriesView', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => response.json())
    .then(data => data);

    return response;
}

async function getCategoryById(id = '') {
    let response = await fetch(PAGE_URL + `/Categories/OnGetById?id='${id}'`, {
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

async function getTypeById(id = '') {
    let response = await fetch(PAGE_URL + `/Types/OnGetById?id='${id}'`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => response.json())
    .then(data => data);

    return response;
}

async function getTypesView() {
    let results = fetch(PAGE_URL + '/Types/OnGetTypesView', {
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
    
    return results;
}

async function getSizesView() {
    let response = await fetch(PAGE_URL + '/Sizes/OnGetSizesView', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => response.json())
    .then(data => data);

    return response;
}

async function getSizeById(id = '') {
    let response = await fetch(PAGE_URL + `/Sizes/OnGetById?id='${id}'`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => response.json())
    .then(data => data);

    return response;
}

async function deleteRecord(id, controllerName, actionName) {
    await fetch(PAGE_URL + `/${controllerName}/${actionName}?id='${id}'`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => response.json())
    .then(data => {
        if(data?.code != 400) {
            window.location = PAGE_URL + `/${controllerName}`;
            renderErrorMessage("Success");
        }

        renderErrorMessage();
        console.error(data);
        return;
    });
}

function renderErrorMessage(message = 'An error occurred while processing your request, see logs.', type = 'danger') {
    let errorElement = document.getElementById('page-error-content');
    let errorMessage = document.createElement('div');
    errorMessage.classList.add('alert', `alert-${type}`);
    errorMessage.textContent = message;

    if(errorElement) {
        errorElement.appendChild(errorMessage);
    }
    
    setTimeout(() => {
        errorMessage.remove();
    }, 3000);
}