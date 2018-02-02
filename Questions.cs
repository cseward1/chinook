// non_usa_customers.sql: Provide a query showing Customers (just their full names, customer ID and country) who are not in the US.
SELECT 
FirstName, 
LastName,
CustomerId, 
Country
FROM
Customer
WHERE 
Country != "USA"

// brazil_customers.sql: Provide a query only showing the Customers from Brazil.
SELECT
FirstName, 
LastName,
CustomerId, 
Country 
FROM
Customer
WHERE
Country = "Brazil"


// brazil_customers_invoices.sql: Provide a query showing the Invoices of customers who are from Brazil. The resultant table should show the customer's full name, Invoice ID, Date of the invoice and billing country.
SELECT
Customer. FirstName,
Customer.LastName,
Invoice.InvoiceId, 
Invoice.BillingCountry
from
Customer
INNER JOIN Invoice ON Invoice.CustomerID = Customer.CustomerId
where
Country = "Brazil"

// sales_agents.sql: Provide a query showing only the Employees who are Sales Agents.
Select 
Title,
FirstName,
LastName
from
Employee
where 
Title = "Sales Support Agent"




// unique_invoice_countries.sql: Provide a query showing a unique/distinct list of billing countries from the Invoice table.
SELECT DISTINCT
BillingCountry
from
Invoice;


// sales_agent_invoices.sql: Provide a query that shows the invoices associated with each sales agent. The resultant table should include the Sales Agent's full name.
// Having Problems with this one - will come back to it 
SELECT
Employee.Title,
Invoice.InvoiceId, 
Invoice.BillingCountry
from
Customer
INNER JOIN Invoice ON Invoice.CustomerID = Customer.CustomerId
where
Title ="Sales Support Agent"




select * from Employee where Title = 'Sales Support Agent'

// invoice_totals.sql: Provide a query that shows the Invoice Total, Customer name, Country and Sale Agent name for all invoices and customers.
// Need a join table for three joins?

// total_invoices_{year}.sql: How many Invoices were there in 2009 and 2011?
SELECT
 Total,
 InvoiceDate
 FROM
 Invoice
 where
 strftime("%Y", InvoiceDate) = "2009"
 OR
 strftime("%Y", InvoiceDate) = "2011"


// total_sales_{year}.sql: What are the respective total sales for each of those years?
// strftime is asking for just the yeat with the %Y 
// its totaling up
 SELECT
 Total (Invoice.Total) 
 AS
 "Total Sales"
 FROM
 Invoice
 where
 strftime("%Y", InvoiceDate) = "2009"
 OR
 strftime("%Y", InvoiceDate) = "2011"


// invoice_37_line_item_count.sql: Looking at the InvoiceLine table, provide a query that COUNTs the number of line items for Invoice ID 37.
select 
i.InvoiceId,
count(li.InvoiceLineId) LineItems
from Invoice i, InvoiceLine li 
where li.InoviceId = i.InvoiceId
groupBy i.InvoiceI
dorder by LineItems desc
limit 1

;



// line_items_per_invoice.sql: Looking at the InvoiceLine table, provide a query that COUNTs the number of line items for each Invoice. HINT: GROUP BY

// line_item_track.sql: Provide a query that includes the purchased track name with each invoice line item.

// line_item_track_artist.sql: Provide a query that includes the purchased track name AND artist name with each invoice line item.

// country_invoices.sql: Provide a query that shows the # of invoices per country. HINT: GROUP BY

// playlists_track_count.sql: Provide a query that shows the total number of tracks in each playlist. The Playlist name should be include on the resulant table.

// tracks_no_id.sql: Provide a query that shows all the Tracks, but displays no IDs. The result should include the Album name, Media type and Genre.

// invoices_line_item_count.sql: Provide a query that shows all Invoices but includes the # of invoice line items.

// sales_agent_total_sales.sql: Provide a query that shows total sales made by each sales agent.

// top_2009_agent.sql: Which sales agent made the most in sales in 2009?
// Steves answer to use as a guide:
select
max(Sales.TotalSales) as TopSales,
Sales.EmployeeName
from
(select
sum(i.Total) TotalSales,
e.FirstName || ' ' || e.LastName as EmployeeName,
strftime ('%Y', i.InvoiceDate) as InvoiceYear
from Invoice i, Employee e ,Customer c
    where i.CustomerId = c.CustomerId
    and  c.SupportRepId =e.EmployeeId
    and InvocieYear = '2009'
    group by EmployeeName
    order by TotalSales desc) Sales
    ;



// Hint: Use the MAX function on a subquery.

// top_agent.sql: Which sales agent made the most in sales over all?



// sales_agent_customer_count.sql: Provide a query that shows the count of customers assigned to each sales agent.
// Steves Answer to use as a guide:
select e.FirstName || ' ' || e.LastName as EmployeeName,
count (c.CustomerId)
from Employee e
join Customer c on c.SupportRepId =e.EmployeeId
group by EmployeeName
;


// sales_per_country.sql: Provide a query that shows the total sales per country.

// top_country.sql: Which country's customers spent the most?

// top_2013_track.sql: Provide a query that shows the most purchased track of 2013.

// top_5_tracks.sql: Provide a query that shows the top 5 most purchased songs.
// Steves answer / use as notes for other problems
// if you have an aggregate function that means you need a groupby statement
select t.Name, count(t.Name) PurchaseCount
from Track t
join InvoiceLine 1 on 1.Track.Id = t.TrackId
group by t.Name
order by PurchaseCount desc
limit 5
;
// top_3_artists.sql: Provide a query that shows the top 3 best selling artists.

// top_media_type.sql: Provide a query that shows the most purchased Media Type.