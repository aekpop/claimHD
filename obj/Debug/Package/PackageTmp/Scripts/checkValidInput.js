function Chkinvalid() {
    var value = document.getElementById('<%= txtMethod.ClientID %>').value;
    if (value != "") {
        //
    } else {
        alert('กรุณาระบุวิธิแก้ไข');
    }

    var value2 = document.getElementById('<%= txtETime.ClientID %>').value;
    if (value2 != "") {
        //
    } else {
        alert('กรุณาระบุเวลาเข้าซ่อม');
    }

    var value3 = document.getElementById('<%= txtEJTime.ClientID %>').value;
    if (value3 != "") {
        //
    } else {
        alert('กรุณาระบุเวลาเข้าซ่อม');
    }
}
