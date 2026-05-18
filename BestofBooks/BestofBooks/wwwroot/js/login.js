// Login modal — AJAX form submission
// jQuery and Bootstrap are already loaded by _Layout.cshtml

document.addEventListener('DOMContentLoaded', function () {
    const loginBtn = document.getElementById('logInBtn');
    if (!loginBtn) return;

    loginBtn.addEventListener('click', function () {
        const username = document.getElementById('loginUsername').value.trim();
        const password = document.getElementById('loginPassword').value;
        const errorEl = document.getElementById('loginError');

        errorEl.style.display = 'none';

        if (!username || !password) {
            errorEl.textContent = 'Please enter both username and password.';
            errorEl.style.display = 'block';
            return;
        }

        // Read the anti-forgery token that _Layout renders automatically.
        // Without this, our global CSRF protection will reject the request.
        const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;

        fetch('/api/user/logIn', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'RequestVerificationToken': token ?? ''
            },
            body: JSON.stringify({ username, password })
        })
            .then(res => {
                if (res.ok) {
                    // Reload the page — the auth cookie is now set,
                    // so the nav will update to show the logged-in state
                    window.location.reload();
                } else {
                    errorEl.style.display = 'block';
                }
            })
            .catch(() => {
                errorEl.textContent = 'Something went wrong. Please try again.';
                errorEl.style.display = 'block';
            });
    });

    // Clear error and fields when the modal is closed
    document.getElementById('loginModal')?.addEventListener('hidden.bs.modal', function () {
        document.getElementById('loginUsername').value = '';
        document.getElementById('loginPassword').value = '';
        document.getElementById('loginError').style.display = 'none';
    });
});