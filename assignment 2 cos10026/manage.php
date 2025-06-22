<!DOCTYPE html>
<html lang="en">


<?php $title = "HR manager queries";
include('head.inc'); ?>

<body>
  <?php include('header.inc'); ?>

<?php
include 'settings.php';

$sql = "SELECT * FROM eoi";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    echo "<table border='1'>
            <tr>
                <th>ID</th>
                <th>Ref_no</th>
                <th>First_name</th>
                <th>Last_name</th>
                <th>DOB</th>
                <th>Gender</th>
                <th>Street_Add</th>
                <th>Suburb_town</th>
                <th>State</th>
                <th>Postcode</th>
                <th>Email</th>
                <th>Phone_num</th>
                <th>Skills</th>
            </tr>";

    // Output data of each row
    while ($row = $result->fetch_assoc()) {
        echo "<tr>
                <td>" . $row["id"] . "</td>
                <td>" . $row["Ref_no"] . "</td>
                <td>" . $row["First_name"] . "</td>
                <td>" . $row["Last_name"] . "</td>
                <td>" . $row["DOB"] . "</td>
                <td>" . $row["Gender"] . "</td>
                <td>" . $row["Street_Add"] . "</td>
                <td>" . $row["suburb_town"] . "</td>
                <td>" . $row["State"] . "</td>
                <td>" . $row["Postcode"] . "</td>
                <td>" . $row["email"] . "</td>
                <td>" . $row["Phone_num"] . "</td>
                <td>" . $row["Skills"]    . "</td>
            </tr>";
    }
    echo "</table>";
} else {
    echo "0 results";
}

$conn->close();
?>
<?php include('footer.inc'); ?>
</body>

</html>