CREATE PROCEDURE [dbo].[AddressStats]
AS

SELECT AddressType, count(1) as AddressCount
FROM AddressModels
GROUP BY AddressType
ORDER BY 1

RETURN 0
