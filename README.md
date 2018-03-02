# LDDPartList
This extracts brick usage informations form a LEGO Digital Designer model file, thus creating a Bill Of Material. 

You can process operation on model via:
- Click _File => Open..._ -- after application start
- Drag & Drog file into application main window -- after application start
- Draw file on application shortcut
- Use in non-interactive mode with command line as shown below:
> lddpartlist.exe  <path_to_model>\my_model.lxf  xml2txt.xsl

You can create own eXtensible Stylesheet Language Transformations. Remember to collect then in tool root directory. Name of this file must be in format as shown below:
> xml2<my_ascii_text>.xsl

Custom *.xsl file can be used only in non-interactive mode.
