window.showPopup = (message, type) => {
    const popup = document.createElement('div');
    popup.className = `popup-message popup-${type}`;
    popup.innerText = message;
    document.body.appendChild(popup);

    setTimeout(() => popup.remove(), 3000);
};
