// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore.FunctionalTests;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.SqlServer.FunctionalTests
{
    public class QueryNavigationsSqlServerTest : QueryNavigationsTestBase<NorthwindQuerySqlServerFixture>
    {
        public override void Select_Where_Navigation()
        {
            base.Select_Where_Navigation();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o.Customer].[CustomerID], [o.Customer].[Address], [o.Customer].[City], [o.Customer].[CompanyName], [o.Customer].[ContactName], [o.Customer].[ContactTitle], [o.Customer].[Country], [o.Customer].[Fax], [o.Customer].[Phone], [o.Customer].[PostalCode], [o.Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
ORDER BY [o].[CustomerID]",
                Sql);
        }

        public override void Select_Where_Navigation_Deep()
        {
            base.Select_Where_Navigation_Deep();

            Assert.StartsWith(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice], [od.Order].[OrderID], [od.Order].[CustomerID], [od.Order].[EmployeeID], [od.Order].[OrderDate], [od.Order.Customer].[CustomerID], [od.Order.Customer].[Address], [od.Order.Customer].[City], [od.Order.Customer].[CompanyName], [od.Order.Customer].[ContactName], [od.Order.Customer].[ContactTitle], [od.Order.Customer].[Country], [od.Order.Customer].[Fax], [od.Order.Customer].[Phone], [od.Order.Customer].[PostalCode], [od.Order.Customer].[Region]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od.Order] ON [od].[OrderID] = [od.Order].[OrderID]
LEFT JOIN [Customers] AS [od.Order.Customer] ON [od.Order].[CustomerID] = [od.Order.Customer].[CustomerID]
ORDER BY [od.Order].[CustomerID]",
                Sql);
        }

        public override void Select_Where_Navigation_Included()
        {
            base.Select_Where_Navigation_Included();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Orders] AS [o]
INNER JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
LEFT JOIN [Customers] AS [c] ON [o].[CustomerID] = [c].[CustomerID]
WHERE [o.Customer].[City] = 'Seattle'",
                Sql);
        }

        public override void Select_Navigation()
        {
            base.Select_Navigation();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o.Customer].[CustomerID], [o.Customer].[Address], [o.Customer].[City], [o.Customer].[CompanyName], [o.Customer].[ContactName], [o.Customer].[ContactTitle], [o.Customer].[Country], [o.Customer].[Fax], [o.Customer].[Phone], [o.Customer].[PostalCode], [o.Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
ORDER BY [o].[CustomerID]",
                Sql);
        }

        public override void Select_Navigations()
        {
            base.Select_Navigations();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o.Customer].[CustomerID], [o.Customer].[Address], [o.Customer].[City], [o.Customer].[CompanyName], [o.Customer].[ContactName], [o.Customer].[ContactTitle], [o.Customer].[Country], [o.Customer].[Fax], [o.Customer].[Phone], [o.Customer].[PostalCode], [o.Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
ORDER BY [o].[CustomerID]",
                Sql);
        }

        public override void Select_Where_Navigations()
        {
            base.Select_Where_Navigations();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o.Customer].[CustomerID], [o.Customer].[Address], [o.Customer].[City], [o.Customer].[CompanyName], [o.Customer].[ContactName], [o.Customer].[ContactTitle], [o.Customer].[Country], [o.Customer].[Fax], [o.Customer].[Phone], [o.Customer].[PostalCode], [o.Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
ORDER BY [o].[CustomerID]",
                Sql);
        }

        public override void Select_Where_Navigation_Multiple_Access()
        {
            base.Select_Where_Navigation_Multiple_Access();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o.Customer].[CustomerID], [o.Customer].[Address], [o.Customer].[City], [o.Customer].[CompanyName], [o.Customer].[ContactName], [o.Customer].[ContactTitle], [o.Customer].[Country], [o.Customer].[Fax], [o.Customer].[Phone], [o.Customer].[PostalCode], [o.Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
ORDER BY [o].[CustomerID]",
                Sql);
        }

        public override void Select_Navigations_Where_Navigations()
        {
            base.Select_Navigations_Where_Navigations();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o.Customer].[CustomerID], [o.Customer].[Address], [o.Customer].[City], [o.Customer].[CompanyName], [o.Customer].[ContactName], [o.Customer].[ContactTitle], [o.Customer].[Country], [o.Customer].[Fax], [o.Customer].[Phone], [o.Customer].[PostalCode], [o.Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
ORDER BY [o].[CustomerID]",
                Sql);
        }

        public override void Select_Where_Navigation_Client()
        {
            base.Select_Where_Navigation_Client();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o.Customer].[CustomerID], [o.Customer].[Address], [o.Customer].[City], [o.Customer].[CompanyName], [o.Customer].[ContactName], [o.Customer].[ContactTitle], [o.Customer].[Country], [o.Customer].[Fax], [o.Customer].[Phone], [o.Customer].[PostalCode], [o.Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
ORDER BY [o].[CustomerID]",
                Sql);
        }

        public override void Select_Singleton_Navigation_With_Member_Access()
        {
            base.Select_Singleton_Navigation_With_Member_Access();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o.Customer].[CustomerID], [o.Customer].[Address], [o.Customer].[City], [o.Customer].[CompanyName], [o.Customer].[ContactName], [o.Customer].[ContactTitle], [o.Customer].[Country], [o.Customer].[Fax], [o.Customer].[Phone], [o.Customer].[PostalCode], [o.Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
ORDER BY [o].[CustomerID]",
                Sql);
        }

        public override void Singleton_Navigation_With_Member_Access()
        {
            base.Singleton_Navigation_With_Member_Access();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o.Customer].[CustomerID], [o.Customer].[Address], [o.Customer].[City], [o.Customer].[CompanyName], [o.Customer].[ContactName], [o.Customer].[ContactTitle], [o.Customer].[Country], [o.Customer].[Fax], [o.Customer].[Phone], [o.Customer].[PostalCode], [o.Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
ORDER BY [o].[CustomerID]",
                Sql);
        }

        public override void Select_Where_Navigation_Scalar_Equals_Navigation_Scalar()
        {
            base.Select_Where_Navigation_Scalar_Equals_Navigation_Scalar();

            Assert.StartsWith(
                @"",
                Sql);
        }

        public override void Select_Where_Navigation_Scalar_Equals_Navigation_Scalar_Projected()
        {
            base.Select_Where_Navigation_Scalar_Equals_Navigation_Scalar_Projected();

            Assert.StartsWith(
                @"",
                Sql);
        }

        public override void Select_Where_Navigation_Equals_Navigation()
        {
            base.Select_Where_Navigation_Equals_Navigation();

            Assert.Equal(
                @"SELECT [o1].[OrderID], [o1].[CustomerID], [o1].[EmployeeID], [o1].[OrderDate], [o2].[OrderID], [o2].[CustomerID], [o2].[EmployeeID], [o2].[OrderDate]
FROM [Orders] AS [o1]
CROSS JOIN [Orders] AS [o2]
WHERE ([o1].[CustomerID] = [o2].[CustomerID]) OR ([o1].[CustomerID] IS NULL AND [o2].[CustomerID] IS NULL)",
                Sql);
        }

        public override void Select_Where_Navigation_Null()
        {
            base.Select_Where_Navigation_Null();

            Assert.Equal(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] IS NULL",
                Sql);
        }

        public override void Select_Where_Navigation_Null_Deep()
        {
            base.Select_Where_Navigation_Null_Deep();

            Assert.Equal(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title], [e.Manager].[EmployeeID], [e.Manager].[City], [e.Manager].[Country], [e.Manager].[FirstName], [e.Manager].[ReportsTo], [e.Manager].[Title]
FROM [Employees] AS [e]
LEFT JOIN [Employees] AS [e.Manager] ON [e].[ReportsTo] = [e.Manager].[EmployeeID]
ORDER BY [e].[ReportsTo]",
                Sql);
        }

        public override void Select_Where_Navigation_Null_Reverse()
        {
            base.Select_Where_Navigation_Null_Reverse();

            Assert.Equal(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] IS NULL",
                Sql);
        }

        public override void Select_collection_navigation_simple()
        {
            base.Select_collection_navigation_simple();

            Assert.Equal(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE N'A' + N'%'

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                Sql);
        }

        public override void Select_collection_navigation_multi_part()
        {
            base.Select_collection_navigation_multi_part();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o.Customer].[CustomerID], [o.Customer].[Address], [o.Customer].[City], [o.Customer].[CompanyName], [o.Customer].[ContactName], [o.Customer].[ContactTitle], [o.Customer].[Country], [o.Customer].[Fax], [o.Customer].[Phone], [o.Customer].[PostalCode], [o.Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
WHERE [o].[CustomerID] = N'ALFKI'
ORDER BY [o].[CustomerID]

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]",
                Sql);
        }

        public override void Collection_select_nav_prop_any()
        {
            base.Collection_select_nav_prop_any();

            Assert.Equal(
                @"SELECT (
    SELECT CASE
        WHEN EXISTS (
            SELECT 1
            FROM [Orders] AS [o0]
            WHERE [c].[CustomerID] = [o0].[CustomerID])
        THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT)
    END
)
FROM [Customers] AS [c]",
                Sql);
        }

        public override void Collection_where_nav_prop_any()
        {
            base.Collection_where_nav_prop_any();

            Assert.Equal(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [c].[CustomerID] = [o].[CustomerID])",
                Sql);
        }

        public override void Collection_where_nav_prop_any_predicate()
        {
            base.Collection_where_nav_prop_any_predicate();

            Assert.Equal(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([o].[OrderID] > 0) AND ([c].[CustomerID] = [o].[CustomerID]))",
                Sql);
        }

        public override void Collection_select_nav_prop_all()
        {
            base.Collection_select_nav_prop_all();

            Assert.Equal(
                @"SELECT (
    SELECT CASE
        WHEN NOT EXISTS (
            SELECT 1
            FROM [Orders] AS [o0]
            WHERE (([c].[CustomerID] = [o0].[CustomerID]) AND [o0].[CustomerID] IS NOT NULL) AND NOT (([o0].[CustomerID] = N'ALFKI') AND [o0].[CustomerID] IS NOT NULL))
        THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT)
    END
)
FROM [Customers] AS [c]",
                Sql);
        }

        public override void Collection_select_nav_prop_all_client()
        {
            base.Collection_select_nav_prop_all_client();

            Assert.StartsWith(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]

SELECT [o1].[OrderID], [o1].[CustomerID], [o1].[EmployeeID], [o1].[OrderDate]
FROM [Orders] AS [o1]",
                Sql);
        }

        public override void Collection_where_nav_prop_all()
        {
            base.Collection_where_nav_prop_all();

            Assert.Equal(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE (([c].[CustomerID] = [o].[CustomerID]) AND [o].[CustomerID] IS NOT NULL) AND NOT (([o].[CustomerID] = N'ALFKI') AND [o].[CustomerID] IS NOT NULL))",
                Sql);
        }

        public override void Collection_where_nav_prop_all_client()
        {
            base.Collection_where_nav_prop_all_client();

            Assert.StartsWith(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                Sql);
        }

        public override void Collection_select_nav_prop_count()
        {
            base.Collection_select_nav_prop_count();

            Assert.Equal(
                @"SELECT (
    SELECT COUNT(*)
    FROM [Orders] AS [o0]
    WHERE [c].[CustomerID] = [o0].[CustomerID]
)
FROM [Customers] AS [c]",
                Sql);
        }

        public override void Collection_where_nav_prop_count()
        {
            base.Collection_where_nav_prop_count();

            Assert.Equal(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (
    SELECT COUNT(*)
    FROM [Orders] AS [o]
    WHERE [c].[CustomerID] = [o].[CustomerID]
) > 5",
                Sql);
        }

        public override void Collection_where_nav_prop_count_reverse()
        {
            base.Collection_where_nav_prop_count_reverse();

            Assert.Equal(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE 5 < (
    SELECT COUNT(*)
    FROM [Orders] AS [o]
    WHERE [c].[CustomerID] = [o].[CustomerID]
)",
                Sql);
        }

        public override void Collection_orderby_nav_prop_count()
        {
            base.Collection_orderby_nav_prop_count();

            Assert.Equal(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY (
    SELECT COUNT(*)
    FROM [Orders] AS [o]
    WHERE [c].[CustomerID] = [o].[CustomerID]
)",
                Sql);
        }

        public override void Collection_select_nav_prop_long_count()
        {
            base.Collection_select_nav_prop_long_count();

            Assert.Equal(
                @"SELECT (
    SELECT COUNT_BIG(*)
    FROM [Orders] AS [o0]
    WHERE [c].[CustomerID] = [o0].[CustomerID]
)
FROM [Customers] AS [c]",
                Sql);
        }

        public override void Select_multiple_complex_projections()
        {
            base.Select_multiple_complex_projections();

            Assert.Equal(
                @"SELECT (
    SELECT COUNT(*)
    FROM [Order Details] AS [o2]
    WHERE [o].[OrderID] = [o2].[OrderID]
), (
    SELECT CASE
        WHEN EXISTS (
            SELECT 1
            FROM [Order Details] AS [od1]
            WHERE ([od1].[UnitPrice] > 10.0) AND ([o].[OrderID] = [od1].[OrderID]))
        THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT)
    END
), CASE
    WHEN [o].[CustomerID] = N'ALFKI'
    THEN N'50' ELSE N'10'
END, [o].[OrderID], (
    SELECT CASE
        WHEN NOT EXISTS (
            SELECT 1
            FROM [Order Details] AS [od2]
            WHERE ([o].[OrderID] = [od2].[OrderID]) AND ([od2].[OrderID] <> 42))
        THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT)
    END
), (
    SELECT COUNT_BIG(*)
    FROM [Order Details] AS [o3]
    WHERE [o].[OrderID] = [o3].[OrderID]
), [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] LIKE N'A' + N'%'",
                Sql);
        }

        public override void Collection_select_nav_prop_sum()
        {
            base.Collection_select_nav_prop_sum();

            Assert.Equal(
                @"SELECT (
    SELECT SUM([o0].[OrderID])
    FROM [Orders] AS [o0]
    WHERE [c].[CustomerID] = [o0].[CustomerID]
)
FROM [Customers] AS [c]",
                Sql);
        }

        public override void Collection_where_nav_prop_sum()
        {
            base.Collection_where_nav_prop_sum();

            Assert.Equal(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (
    SELECT SUM([o].[OrderID])
    FROM [Orders] AS [o]
    WHERE [c].[CustomerID] = [o].[CustomerID]
) > 1000",
                Sql);
        }

        public override void Collection_select_nav_prop_first_or_default()
        {
            base.Collection_select_nav_prop_first_or_default();

            // TODO: Projection sub-query lifting
            Assert.StartsWith(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                Sql);
        }

        public override void Collection_select_nav_prop_first_or_default_then_nav_prop()
        {
            base.Collection_select_nav_prop_first_or_default_then_nav_prop();

            // TODO: Projection sub-query lifting
            Assert.StartsWith(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                Sql);
        }

        public override void Navigation_fk_based_inside_contains()
        {
            base.Navigation_fk_based_inside_contains();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] IN (N'ALFKI')",
                Sql);
        }

        public override void Navigation_inside_contains()
        {
            base.Navigation_inside_contains();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o.Customer].[CustomerID], [o.Customer].[Address], [o.Customer].[City], [o.Customer].[CompanyName], [o.Customer].[ContactName], [o.Customer].[ContactTitle], [o.Customer].[Country], [o.Customer].[Fax], [o.Customer].[Phone], [o.Customer].[PostalCode], [o.Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
ORDER BY [o].[CustomerID]",
                Sql);
        }

        public override void Navigation_inside_contains_nested()
        {
            base.Navigation_inside_contains_nested();

            Assert.Equal(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice], [od.Order].[OrderID], [od.Order].[CustomerID], [od.Order].[EmployeeID], [od.Order].[OrderDate], [od.Order.Customer].[CustomerID], [od.Order.Customer].[Address], [od.Order.Customer].[City], [od.Order.Customer].[CompanyName], [od.Order.Customer].[ContactName], [od.Order.Customer].[ContactTitle], [od.Order.Customer].[Country], [od.Order.Customer].[Fax], [od.Order.Customer].[Phone], [od.Order.Customer].[PostalCode], [od.Order.Customer].[Region]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od.Order] ON [od].[OrderID] = [od.Order].[OrderID]
LEFT JOIN [Customers] AS [od.Order.Customer] ON [od.Order].[CustomerID] = [od.Order.Customer].[CustomerID]
ORDER BY [od.Order].[CustomerID]",
                Sql);
        }

        public override void Navigation_from_join_clause_inside_contains()
        {
            base.Navigation_from_join_clause_inside_contains();

            Assert.Equal(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice], [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o.Customer].[CustomerID], [o.Customer].[Address], [o.Customer].[City], [o.Customer].[CompanyName], [o.Customer].[ContactName], [o.Customer].[ContactTitle], [o.Customer].[Country], [o.Customer].[Fax], [o.Customer].[Phone], [o.Customer].[PostalCode], [o.Customer].[Region]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [o] ON [od].[OrderID] = [o].[OrderID]
LEFT JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
ORDER BY [o].[CustomerID]",
                Sql);
        }

        public override void Where_subquery_on_navigation()
        {
            base.Where_subquery_on_navigation();

            Assert.Equal(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE EXISTS (
    SELECT 1
    FROM (
        SELECT [o].[OrderID], [o].[ProductID]
        FROM [Order Details] AS [o]
        WHERE [p].[ProductID] = [o].[ProductID]
    ) AS [t00]
    INNER JOIN (
        SELECT TOP(1) [orderDetail].[OrderID], [orderDetail].[ProductID]
        FROM [Order Details] AS [orderDetail]
        WHERE [orderDetail].[Quantity] = 1
    ) AS [t1] ON ([t00].[OrderID] = [t1].[OrderID]) AND ([t00].[ProductID] = [t1].[ProductID]))",
                Sql);
        }

        public override void Navigation_in_subquery_referencing_outer_query()
        {
            base.Navigation_in_subquery_referencing_outer_query();

            Assert.Equal(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o.Customer].[Country]
FROM [Orders] AS [o]
INNER JOIN [Customers] AS [o.Customer] ON [o].[CustomerID] = [o.Customer].[CustomerID]
WHERE (
    SELECT COUNT(*)
    FROM [Order Details] AS [od]
    INNER JOIN [Orders] AS [od.Order] ON [od].[OrderID] = [od.Order].[OrderID]
    INNER JOIN [Customers] AS [od.Order.Customer] ON [od.Order].[CustomerID] = [od.Order.Customer].[CustomerID]
    WHERE ([o.Customer].[Country] = [od.Order.Customer].[Country]) OR ([o.Customer].[Country] IS NULL AND [od.Order.Customer].[Country] IS NULL)
) > 0",
                Sql);
        }

        protected override void ClearLog() => TestSqlLoggerFactory.Reset();

        private static string Sql => TestSqlLoggerFactory.Sql;

        public QueryNavigationsSqlServerTest(NorthwindQuerySqlServerFixture fixture, ITestOutputHelper testOutputHelper)
            : base(fixture)
        {
            //TestSqlLoggerFactory.CaptureOutput(testOutputHelper);
        }
    }
}