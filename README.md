# DHCPConfChecker
ISC-DHCP-ServerとKeaのMACアドレスによる固定IPの設定に重複がないか調べる

- ISC-DHCP-Serverのdhcpd.conf
- Kea-DHCPの設定ファイル (reservationsのオブジェクト部分のみ)
- ISC-DHCP-ServerのLDAP

![dhcpconfchecker](https://github.com/user-attachments/assets/968e5764-5ee9-4b8e-9362-b053ee1bfed7)


## できること

- ホスト名の重複チェック
- IPアドレスの重複チェック
- MACアドレスの重複チェック
- ホスト、IPアドレス、MACアドレスの一覧のCSV出力

## ボタン説明

| グループ | ボタン | 意味 |
+---+---+---
| Dup Check | isc-conf | ISC-DHCP-Serverの設定ファイルの重複チェック |
| Dup Check | isc-ldif | ISC-DHCP-ServerのLDAPデータの重複チェック |
| Dup Check | kea-ldif | Keaの設定ファイルの重複チェック |
| Export List | isc-conf | ISC-DHCP-Serverの設定ファイルのホスト一覧の出力 |
| Export List | isc-ldif | ISC-DHCP-ServerのLDAPデータのホスト一覧の出力 |
| Export List | kea-ldif | Keaの設定ファイルのホスト一覧の出力 |

## 動作環境

- Windows 10, Windows 11
- .NET Framework 4.8.1
