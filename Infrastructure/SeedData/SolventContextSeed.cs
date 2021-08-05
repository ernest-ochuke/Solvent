using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.enums;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Infrastructure.SeedData
{
    public class SolventContextSeed
    {
        public static void SeedAsync(SolventContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ChipTypes.Any())
                {
                    List<ChipType> chipTypes = new List<ChipType>{
                        new ChipType{  Name = "Gemalto R9", ExpirationDate = DateTime.Today.AddYears(5),LoaReferenceNumber="LBGTO2346732"},
                         new ChipType{  Name = "Kona D2350", ExpirationDate = DateTime.Today.AddYears(6),LoaReferenceNumber="LBKN2346734"},

                    };
                    foreach (var chipType in chipTypes)
                    {
                        context.ChipTypes.Add(chipType);
                    }
                     context.SaveChanges();
                }
                if (!context.Banks.Any())
                {
                    List<Bank> banks = new List<Bank>{
                        new Bank{  Name = "Standard Chartered Bank", UniqueIdentityNumber = "SCBN2021-01"},
                         new Bank{  Name = "Globus Bank", UniqueIdentityNumber = "GLBN2021-03"}
                    };
                    foreach (var bank in banks)
                    {
                        context.Banks.Add(bank);
                    }
                    context.SaveChanges();
                }
                if (!context.ChipCertifications.Any())
                {
                    List<ChipCertification> ccs = new List<ChipCertification>{
                        new ChipCertification{  BankId =1,CertificationStatus = CertificationStatus.Ongoing, ChipTypeId =1,CertificationType = CertificationType.WhitePlastic,StartDate = DateTime.Now, ReferenceNumber ="LB675456787"},
                        new ChipCertification{  BankId =2,CertificationStatus = CertificationStatus.Ongoing, ChipTypeId =2,CertificationType = CertificationType.ChipPersonalizationValidation,StartDate = DateTime.Now, ReferenceNumber ="UL2345343"}

                    };
                    foreach (var cs in ccs)
                    {
                        context.ChipCertifications.Add(cs);
                    }
                     context.SaveChanges();
                }

                if (!context.CardProducts.Any())
                {
                    List<CardProduct> cardproducts = new List<CardProduct>{
                        new CardProduct{  BankId =1,ChipId =1,ProductName ="SCBGold",Comment ="Standard Chartered bank Gold product", ChipCertificationId =1},

                    };
                    foreach (var cp in cardproducts)
                    {
                        context.CardProducts.Add(cp);
                    }
                    context.SaveChanges();
                }
                if (!context.ChipInventories.Any())
                {
                    List<ChipInventory> cis = new List<ChipInventory>{
                        new ChipInventory{  DateEntered = DateTime.Now,Quantity = 200000,KCV = "543233",ChipTypeId =1},
                        new ChipInventory{  DateEntered = DateTime.Now,Quantity = 10000,KCV = "454333",ChipTypeId =2},
                    };
                    foreach (var ci in cis)
                    {
                        context.ChipInventories.Add(ci);
                    }
                    context.SaveChanges();
                }
                {
                    List<ChipInventoryHistory> cih = new List<ChipInventoryHistory>{
                        new ChipInventoryHistory{  ChipInventoryId=1,Quantity =1234,Action = RequestType.Substract,Requester = "Ernest Okosobo",MediatorName ="Boma Edosonwan",Description = "Remove from stock for live job",Approved = true,DateRequested = DateTime.Now},
                        new ChipInventoryHistory{ ChipInventoryId=1,Quantity =20000,Action = RequestType.Substract,Requester = "Ernest Okosobo",MediatorName ="Boma Edosonwan",Description = "Remove from stock for live job",Approved = true,DateRequested= DateTime.Now}
                    };
                    foreach (var ci in cih)
                    {
                        context.ChipInventoryHistories.Add(ci);
                    }
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
               var logger = loggerFactory.CreateLogger<SolventContext>();
                logger.LogError(ex.Message);
              

            }
        }
    }
}