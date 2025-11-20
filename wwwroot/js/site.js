<script>
    function checkFileSize(input) {
        const fileSizeError = document.getElementById('fileSizeError');
    const files = input.files;
    let totalSize = 0;
    for (let i = 0; i < files.length; i++) {
        totalSize += files[i].size;
        }
        if (totalSize > 500 * 1024 * 1024) {
        fileSizeError.style.display = 'block';
    input.value = '';
    return false;
        } else {
        fileSizeError.style.display = 'none';
        }
    }

    function calculateAmount() {
        const hours = parseFloat(document.getElementById("HoursWorked").value) || 0;
    const rate = parseFloat(document.getElementById("HourlyRate").value) || 0;
    const amount = hours * rate;
    document.getElementById("Amount").value = amount;
    }

    document.getElementById("HoursWorked").addEventListener("input", calculateAmount);
    document.getElementById("HourlyRate").addEventListener("input", calculateAmount);
</script>

