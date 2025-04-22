import csv
import random
from datetime import datetime, timedelta

def generate_transactions_data(num_records=50):
    """
    Generates data for the transactions table.

    Args:
        num_records (int, optional): The number of transaction records to generate. Defaults to 50.

    Returns:
        list: A list of dictionaries, where each dictionary represents a transaction record.
    """
    payment_methods = ['credit_card', 'debit_card', 'paypal', 'bank_transfer']
    status_options = ['success', 'failed', 'pending']
    # sending_account_number
    bookings_ids = [f"BOOK-{i:06d}" for i in range(1, 51)]  # BOOK-000001 to BOOK-000050

    transactions_data = []
    for i in range(num_records):
        transaction_id = f"TXN-{i+1:06d}"
        amount = round(random.uniform(10, 1000), 2)  # Example range: $10 to $1000
        transaction_date = datetime.now() - timedelta(days=random.randint(0, 365))  # Random date in the past year
        payment_method = random.choice(payment_methods)
        booking_id = random.choice(bookings_ids)
        status = random.choice(status_options)
        sending_account_number = ''.join(random.choice("0123456789") for _ in range(16)) # Generate a 16-digit account number

        transactions_data.append({
            "transaction_id": transaction_id,
            "amount": amount,
            "transaction_date": transaction_date.strftime('%Y-%m-%d %H:%M:%S'),
            "payment_method": payment_method,
            "booking_id": booking_id,
            "status": status,
            "sending_account_number": sending_account_number
        })
    return transactions_data

def write_to_csv(data, filename="transactions_data.csv"):
    """
    Writes the generated transactions data to a CSV file.

    Args:
        data (list): A list of dictionaries, where each dictionary represents a transaction record.
        filename (str, optional): The name of the CSV file to write to.
    """
    if not data:
        print("No data to write to CSV.")
        return
    fieldnames = data[0].keys()
    try:
        with open(filename, mode='w', newline='', encoding='utf-8') as csvfile:
            writer = csv.DictWriter(csvfile, fieldnames=fieldnames)
            writer.writeheader()
            writer.writerows(data)
        print(f"Data successfully written to {filename}")
    except Exception as e:
        print(f"An error occurred while writing to CSV: {e}")

if __name__ == "__main__":
    transactions_data = generate_transactions_data(num_records=50)
    write_to_csv(transactions_data)
