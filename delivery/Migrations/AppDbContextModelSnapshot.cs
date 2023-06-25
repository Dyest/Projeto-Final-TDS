﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using delivery.Data;

#nullable disable

namespace delivery.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("delivery.Models.ClienteModel", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Situacao")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("delivery.Models.Favorito", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduto")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TEXT");

                    b.HasKey("IdCliente", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.ToTable("Favorito");
                });

            modelBuilder.Entity("delivery.Models.ItemPedidoModel", b =>
                {
                    b.Property<int>("IdPedido")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduto")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Quantidade")
                        .HasColumnType("REAL");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPedido", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.ToTable("ItemPedido");
                });

            modelBuilder.Entity("delivery.Models.PedidoModel", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClienteModelIdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataHoraPedido")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Situacao")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPedido");

                    b.HasIndex("ClienteModelIdCliente");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("delivery.Models.ProdutoModel", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Estoque")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<double?>("Preco")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.HasKey("IdProduto");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("delivery.Models.Visitado", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduto")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TEXT");

                    b.HasKey("IdCliente", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.ToTable("Visitado");
                });

            modelBuilder.Entity("delivery.Models.ClienteModel", b =>
                {
                    b.OwnsOne("delivery.Models.EnderecoModel", "Endereco", b1 =>
                        {
                            b1.Property<int>("ClienteModelIdCliente")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Bairro")
                                .HasMaxLength(50)
                                .HasColumnType("TEXT");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Cidade")
                                .HasMaxLength(50)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Complemento")
                                .HasMaxLength(100)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Estado")
                                .HasMaxLength(2)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Logradouro")
                                .HasMaxLength(100)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Referencia")
                                .HasMaxLength(100)
                                .HasColumnType("TEXT");

                            b1.HasKey("ClienteModelIdCliente");

                            b1.ToTable("Cliente");

                            b1.WithOwner()
                                .HasForeignKey("ClienteModelIdCliente");
                        });

                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("delivery.Models.Favorito", b =>
                {
                    b.HasOne("delivery.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("delivery.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("delivery.Models.ItemPedidoModel", b =>
                {
                    b.HasOne("delivery.Models.PedidoModel", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("delivery.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("delivery.Models.PedidoModel", b =>
                {
                    b.HasOne("delivery.Models.ClienteModel", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteModelIdCliente");

                    b.OwnsOne("delivery.Models.EnderecoModel", "Endereco", b1 =>
                        {
                            b1.Property<int>("PedidoModelIdPedido")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Bairro")
                                .HasMaxLength(50)
                                .HasColumnType("TEXT");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Cidade")
                                .HasMaxLength(50)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Complemento")
                                .HasMaxLength(100)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Estado")
                                .HasMaxLength(2)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Logradouro")
                                .HasMaxLength(100)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Referencia")
                                .HasMaxLength(100)
                                .HasColumnType("TEXT");

                            b1.HasKey("PedidoModelIdPedido");

                            b1.ToTable("Pedido");

                            b1.WithOwner()
                                .HasForeignKey("PedidoModelIdPedido");
                        });

                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("delivery.Models.Visitado", b =>
                {
                    b.HasOne("delivery.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("delivery.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("delivery.Models.ClienteModel", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("delivery.Models.PedidoModel", b =>
                {
                    b.Navigation("ItensPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
