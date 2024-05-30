try {
    // Получение всех пород
    async function getBreeds() {
        // отправляет запрос и получаем ответ
        const response = await fetch("/api/breeds", {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
        // если запрос прошел нормально
        if (response.ok === true) {
            // получаем данные
            const breeds = await response.json();
            const rows = document.querySelector("tbody");
            // добавляем полученные элементы в таблицу
            breeds.forEach(breed => rows.append(row(breed)));
        }
        else
            alert('Произошла ошибка при получении данных.');
    }
    // Получение одной породы
    async function getBreed(индекс_породы) {
        const response = await fetch(`/api/breeds/${индекс_породы}`, {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
        if (response.ok === true) {
            const breed = await response.json();
            document.getElementById("breedId").value = breed.индекс_породы;
            document.getElementById("breedName").value = breed.название;
        }
        else
            alert('Произошла ошибка при получении данных.');
    }
    // Добавление породы
    async function createBreed(breedId, breedName) {

        const response = await fetch("api/breeds", {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify({
                индекс_породы: breedId,
                название: breedName,
            })
        });
        if (response.ok === true) {
            const breeds = await response.json();
            document.querySelector("tbody").append(row(breeds));
        }
        else
            alert('Произошла ошибка при создании записи.');
    }
    // Изменение породы
    async function editBreed(breedId, breedName) {
        const response = await fetch("api/breeds", {
            method: "PUT",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify({
                индекс_породы: breedId,
                название: breedName,
            })
        });
        if (response.ok === true) {
            const breeds = await response.json();
            document.querySelector(`tr[data-rowid='${breeds.индекс_породы}']`).replaceWith(row(breeds));
        }
        else
            alert('Произошла ошибка при изменении данных.');
    }
    // Удаление породы
    async function deleteBreed(индекс_породы) {
        const response = await fetch(`/api/breeds/${индекс_породы}`, {
            method: "DELETE",
            headers: { "Accept": "application/json" }
        });
        if (response.ok === true) {
            const breeds = await response.json();
            document.querySelector(`tr[data-rowid='${breeds.индекс_породы}']`).remove();
        }
        else
            alert('Произошла ошибка при удалении данных.');
    }

    // сброс данных формы после отправки
    function reset() {
        document.getElementById("breedId").value =
            document.getElementById("breedName").value = "";
    }
    // создание строки для таблицы
    function row(breeds) {

        const tr = document.createElement("tr");
        tr.setAttribute("data-rowid", breeds.индекс_породы);

        const idTd = document.createElement("td");
        idTd.append(breeds.индекс_породы);
        tr.append(idTd);

        const nameTd = document.createElement("td");
        nameTd.append(breeds.название);
        tr.append(nameTd);

        const linksTd = document.createElement("td");

        const editLink = document.createElement("button");
        editLink.append("Изменить");
        editLink.addEventListener("click", async () => await getBreed(breeds.индекс_породы));
        linksTd.append(editLink);

        const removeLink = document.createElement("button");
        removeLink.append("Удалить");
        removeLink.addEventListener("click", async () => await deleteBreed(breeds.индекс_породы));

        linksTd.append(removeLink);
        tr.appendChild(linksTd);

        return tr;
    }
    // сброс значений формы
    document.getElementById("resetBtn").addEventListener("click", () => reset());

    // отправка формы
    document.getElementById("saveBtn").addEventListener("click", async () => {

        const индекс_породы = document.getElementById("breedId").value;
        const название = document.getElementById("breedName").value;
        // отправляет запрос и получаем ответ
        const response = await fetch("/api/breeds", {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
        // если запрос прошел нормально
        if (response.ok === true) {
            const breeds = await response.json();
            const breedIndices = Object.keys(breeds);
            if (!breedIndices.includes(индекс_породы.toString()))
                await createBreed(индекс_породы, название);
            else
                await editBreed(индекс_породы, название);
            reset();
        }
        else
            alert('Произошла ошибка при получении данных.');
    });

    // загрузка пород
    getBreeds();
}
catch {
    // выводим сообщение об ошибке для пользователя
    alert('Неизвестаня ошибка!');
}